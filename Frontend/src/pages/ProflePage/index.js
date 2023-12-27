import React, { useState, useEffect } from "react";
import {
  Descriptions,
  Input,
  Radio,
  Button,
  Space,
  Row,
  Modal,
  Form,
  message,
  Col,
} from "antd";
import UploadAvatar from "../../components/UploadAvatar";
import "./ProfilePage.css";
const getCookie = (cookieName) => {
  const cookies = document.cookie.split("; ");
  for (const cookie of cookies) {
    const [name, value] = cookie.split("=");
    if (name === cookieName) {
      return value;
    }
  }
  return null;
};

function ProfilePage() {
  const [isEditing, setIsEditing] = useState(false);
  const jwtToken = getCookie("accessToken");
  const userId = getCookie("userid");
  const [userData, setUserData] = useState(null);
  const [editedData, setEditedData] = useState({
    phonenumber: null,
    dob: null,
    sex: null,
  });
  const [changePasswordData, setChangePasswordData] = useState({
    oldPassword: "",
    newPassword: "",
    confirmNewPassword: "",
  });
  const [isChangePasswordModalVisible, setChangePasswordModalVisible] =
    useState(false);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const apiUrl = `https://localhost:7139/api/User/${userId}`;

        const response = await fetch(apiUrl, {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwtToken}`,
          },
        });

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        setUserData(data);
        setEditedData({
          phonenumber: data.phonenumber,
          dob: data.dob,
          sex: data.sex,
        });
      } catch (error) {
        console.error("Error fetching user data:", error);
      }
    };

    fetchUserData();
  }, [userId, jwtToken]);

  const handleEditClick = () => {
    setIsEditing(true);
  };

  const handleSaveClick = async () => {
    try {
      const formData = new FormData();
      formData.append("id", userId);
      formData.append("firstname", userData.firstname);
      formData.append("lastname", userData.lastname);
      formData.append("dob", editedData.dob);
      formData.append("sex", editedData.sex);
      formData.append("phonenumber", editedData.phonenumber);
      console.log(formData);
      const response = await fetch(
        `https://localhost:7139/api/User/updateuser`,
        {
          method: "POST",
          headers: {
            Authorization: `Bearer ${jwtToken}`,
          },
          body: formData,
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      setUserData({
        ...userData,
        phonenumber: editedData.phonenumber,
        dob: editedData.dob,
        sex: editedData.sex,
      });
      setIsEditing(false);
      window.location.reload();
    } catch (error) {
      console.error("Error saving user data:", error);
    }
  };

  const handleCancelClick = () => {
    setEditedData({
      phonenumber: userData?.phonenumber,
      dob: userData?.dob,
      sex: userData?.sex,
    });
    setIsEditing(false);
  };

  const handleInputChange = (field, value) => {
    setEditedData({
      ...editedData,
      [field]: value,
    });
  };

  const handleRadioChange = (e) => {
    handleInputChange("sex", e.target.value);
  };

  const handleChangePasswordClick = () => {
    setChangePasswordModalVisible(true);
  };

  const handleOldPasswordChange = (e) => {
    setChangePasswordData({
      ...changePasswordData,
      oldPassword: e.target.value,
    });
  };

  const handleNewPasswordChange = (e) => {
    setChangePasswordData({
      ...changePasswordData,
      newPassword: e.target.value,
    });
  };

  const handleConfirmNewPasswordChange = (e) => {
    setChangePasswordData({
      ...changePasswordData,
      confirmNewPassword: e.target.value,
    });
  };

  const handleModalCancel = () => {
    // Reset the change password form state and hide the modal
    setChangePasswordData({
      oldPassword: "",
      newPassword: "",
      confirmNewPassword: "",
    });
    setChangePasswordModalVisible(false);
  };

  const handleChangePasswordSave = async () => {
    try {
      const apiUrl = "https://localhost:7139/api/User/ChangePassword";
      const jwtToken = getCookie("accessToken");

      const formData = new FormData();
      formData.append("user_id", userId);
      formData.append("oldPassword", changePasswordData.oldPassword);
      formData.append("newPassword", changePasswordData.newPassword);
      formData.append(
        "confirmnewPassword",
        changePasswordData.confirmNewPassword
      );

      const response = await fetch(apiUrl, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${jwtToken}`,
        },
        body: formData,
      });

      if (!response.ok) {
        try {
          const error = await response.text();
          if (error) {
            message.error(`${error}`);
          }
        } catch (error) {
          // Handle non-JSON response or other errors
          message.error("Please try again later.");
        }
      }
      if (response.ok) {
        message.success("Password changed successfully!");

        setChangePasswordData({
          oldPassword: "",
          newPassword: "",
          confirmNewPassword: "",
        });
        setChangePasswordModalVisible(false);
      }
    } catch (error) {
      console.error("Error changing password:", error);
      message.error("Failed to change password. Please try again later.");
    }
  };

  return (
    <div>
      <Row>
        <h2 className="detail_h2">THÔNG TIN CÁ NHÂN</h2>
      </Row>
      <div className="cover">
        <Col className="profilepage_container">
          {userData && (
            <Descriptions className="description" column={1}>
              <Descriptions.Item label="First Name">
                {userData.firstname}
              </Descriptions.Item>
              <Descriptions.Item label="Last Name">
                {userData.lastname}
              </Descriptions.Item>
              <Descriptions.Item label="Date of Birth">
                {isEditing ? (
                  <Input
                    value={editedData.dob}
                    onChange={(e) => handleInputChange("dob", e.target.value)}
                  />
                ) : (
                  userData.dob || "N/A"
                )}
              </Descriptions.Item>
              <Descriptions.Item label="Sex">
                {isEditing ? (
                  <Radio.Group
                    onChange={handleRadioChange}
                    value={editedData.sex}
                  >
                    <Radio value="true">Nam</Radio>
                    <Radio value="false">Nữ</Radio>
                  </Radio.Group>
                ) : userData.sex ? (
                  "Nam"
                ) : (
                  "Nữ"
                )}
              </Descriptions.Item>
              <Descriptions.Item label="Phone Number">
                {isEditing ? (
                  <Input
                    value={editedData.phonenumber}
                    onChange={(e) =>
                      handleInputChange("phonenumber", e.target.value)
                    }
                  />
                ) : (
                  userData.phonenumber || "N/A"
                )}
              </Descriptions.Item>
              <Descriptions.Item label="Email">
                {userData.email}
              </Descriptions.Item>
            </Descriptions>
          )}
          <Space>
            {isEditing ? (
              <>
                <Button type="primary" onClick={handleSaveClick}>
                  Lưu
                </Button>
                <Button onClick={handleCancelClick}>Hủy</Button>
              </>
            ) : (
              <Button
                size="large"
                className="profilepage_button"
                onClick={handleEditClick}
              >
                Thay đổi
              </Button>
            )}
          </Space>
        </Col>

        <Row>
          <h2 className="detail_h2">ĐỔI MẬT KHẨU</h2>
          <div className="profilepage_container">
            <Button
              size="large"
              className="profilepage_button"
              onClick={handleChangePasswordClick}
            >
              Đổi mật khẩu
            </Button>
          </div>
        </Row>
        <Modal
          title="Change Password"
          visible={isChangePasswordModalVisible}
          onCancel={handleModalCancel}
          footer={[
            <Button key="cancel" onClick={handleModalCancel}>
              Cancel
            </Button>,
            <Button
              key="save"
              type="primary"
              onClick={handleChangePasswordSave}
            >
              Save Password
            </Button>,
          ]}
        >
          <Form layout="vertical">
            <Form.Item
              className="no_margin"
              label={<p className="label">Mật khẩu cũ</p>}
              name="oldpassword"
              rules={[
                {
                  required: true,
                  message: "Please input your old password!",
                },
              ]}
            >
              <Input.Password
                name="oldpassword"
                placeholder="Mật khẩu cũ"
                value={changePasswordData.oldPassword}
                onChange={handleOldPasswordChange}
              />
            </Form.Item>
            <Form.Item
              className="no_margin red_star"
              label={<p className="label">Mật khẩu Mới</p>}
              name="newpassword"
              rules={[
                {
                  required: true,
                  message: "Please confirm your new password!",
                },
                {
                  validator: (_, value) => {
                    if (value.length <= 6) {
                      return Promise.reject(
                        "Password should be at least 6 characters"
                      );
                    }
                    if (!/[A-Z]/.test(value)) {
                      return Promise.reject(
                        "Password should contain at least one uppercase letter"
                      );
                    }
                    if (!/[a-z]/.test(value)) {
                      return Promise.reject(
                        "Password should contain at least one lowercase letter"
                      );
                    }
                    if (!/\d/.test(value)) {
                      return Promise.reject(
                        "Password should contain at least one digit"
                      );
                    }
                    if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
                      return Promise.reject(
                        "Password should contain at least one special character"
                      );
                    }
                    return Promise.resolve();
                  },
                },
              ]}
            >
              <Input.Password
                value={changePasswordData.newPassword}
                placeholder="Mật khẩu mới"
                name="newpassword"
                onChange={handleNewPasswordChange}
              />
            </Form.Item>
            <Form.Item
              className="no_margin"
              label={<p className="label">Xác nhận mật khẩu mới</p>}
              name="confirmpassword"
              dependencies={["newpassword"]}
              hasFeedback
              rules={[
                {
                  required: true,
                  message: "Please confirm your new password!",
                },
                ({ getFieldValue }) => ({
                  validator(_, value) {
                    if (!value || getFieldValue("newpassword") === value) {
                      return Promise.resolve();
                    }
                    return Promise.reject(
                      new Error(
                        "The new password that you entered do not match!"
                      )
                    );
                  },
                }),
              ]}
            >
              <Input.Password
                value={changePasswordData.confirmNewPassword}
                placeholder="xác nhận mật khẩu mới"
                name="confirmnewpassword"
                onChange={handleConfirmNewPasswordChange}
              />
            </Form.Item>
          </Form>
        </Modal>
        <Row>
          <h2 className="detail_h2">LỊCH SỬ GIAO DỊCH</h2>
        </Row>
      </div>
    </div>
  );
}

export default ProfilePage;
