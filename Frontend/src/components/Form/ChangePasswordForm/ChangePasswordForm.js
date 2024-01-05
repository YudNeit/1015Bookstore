import { Typography } from "antd";
import "../styleForm.css";
import { useState, useEffect } from "react";
import { Button, Form, Input, ConfigProvider, message } from "antd";
import { useNavigate } from "react-router-dom";

const { Title } = Typography;

function ChangePassword() {
  const navigate = useNavigate();
  const [isSuccess, setSuccess] = useState(false);
  const [password, setPassword] = useState("");
  const [confirmpassword, setConfirmpassword] = useState("");

  const onFinish = (values) => {
    setSuccess(true);
    handleChange();
    console.log("Success:", values);
  };

  const onFinishFailed = (errorInfo) => {
    setSuccess(false);
    message.error(`Vui lòng nhập đầy đủ thông tin!`);
    console.log("Failed:", errorInfo);
  };

  useEffect(() => {}, []);

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

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    if (name === "password") {
      setPassword(value);
    } else if (name === "confirmpassword") {
      setConfirmpassword(value);
    }
  };

  const handleChange = async () => {
    try {
      const apiUrl = `https://localhost:7139/api/User/ChangePasswordForgotPassword`;
      const jwtToken = getCookie("forgotToken");

      const data = {
        sUser_tokenFP: jwtToken,
        sUser_password: password,
        sUser_confirmpassword: confirmpassword,
      };
      console.log(data);
      const response = await fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        try {
          const error = await response.text();
          if (error) {
            message.error(`${error}`);
          }
        } catch (error) {
          message.error("Change Password failed.");
        }
      } else {
        message.success("Change Password is successful.");
        document.cookie = `forgotToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/`;
        navigate(`/sign_in`);
        window.location.reload();
      }
    } catch (error) {
      console.error("Error Change Password:", error);
      message.error("Confirmation Code failed. Please try again later.");
    }
  };

  return (
    <div className="background">
      <Form
        layout="vertical"
        className="changepassword_form"
        initialValues={{
          remember: true,
        }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        autoComplete="off"
      >
        <Typography
          style={{
            fontWeight: "bolder",
            fontSize: 36,
          }}
        >
          Đổi mật khẩu
        </Typography>
        <Form.Item
          className="no_margin"
          label={<p className="label">Mật khẩu</p>}
          name="password"
          rules={[
            {
              required: true,
              message: "Please input your password!",
            },
            {
              validator: (_, value) => {
                if (!value) {
                  return Promise.reject("Xin vui lòng nhập Mật khẩu!");
                }

                if (value.length < 6) {
                  return Promise.reject("Mật khẩu phải chứa ít nhất 6 kí tự!");
                }

                if (!/[A-Z]/.test(value)) {
                  return Promise.reject(
                    "Mật khẩu phải chứa tối thiểu 1 ký tự in hoa!"
                  );
                }

                if (!/[a-z]/.test(value)) {
                  return Promise.reject(
                    "Mật khẩu phải chứa tối thiểu 1 ký tự thường!"
                  );
                }

                if (!/\d/.test(value)) {
                  return Promise.reject(
                    "Mật khẩu phải chứa tối thiểu 1 ký tự số!"
                  );
                }

                if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
                  return Promise.reject(
                    "Mật khẩu phải chứa tối thiểu 1 ký tự đặc biệt!"
                  );
                }

                return Promise.resolve();
              },
            },
          ]}
        >
          <Input.Password
            size="large"
            placeholder="Mật khẩu"
            name="password"
            value={password}
            onChange={handleInputChange}
          />
        </Form.Item>
        <Form.Item
          className="no_margin"
          label={<p className="label">Xác nhận mật khẩu</p>}
          name="confirmpassword"
          dependencies={["password"]}
          hasFeedback
          rules={[
            {
              required: true,
              message: "Please confirm your password!",
            },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (!value || getFieldValue("password") === value) {
                  return Promise.resolve();
                }
                return Promise.reject(
                  new Error("The new password that you entered do not match!")
                );
              },
            }),
          ]}
        >
          <Input.Password
            size="large"
            placeholder="Xác nhận mật khẩu"
            name="confirmpassword"
            value={confirmpassword}
            onChange={handleInputChange}
          />
        </Form.Item>
        <Form.Item className="no_margin">
          <ConfigProvider
            theme={{
              token: {
                colorBorder: "none",
              },
            }}
          >
            <Button
              className="button"
              block
              size="large"
              type="default"
              htmlType="submit"
            >
              Xác nhận
            </Button>
          </ConfigProvider>
        </Form.Item>
      </Form>
    </div>
  );
}

export default ChangePassword;
