import { Typography } from "antd";
import "../style.css";
import { Button, Form, Input, ConfigProvider, message } from "antd";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
const { Title } = Typography;

function Logup() {
  const navigate = useNavigate();
  const [lastname, setLastname] = useState("");
  const [firstname, setFirstname] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmpassword, setConfirmpassword] = useState("");
  const [email, setEmail] = useState("");
  const [isSuccess, setSuccess] = useState(false);

  useEffect(() => {}, []);

  const onFinish = (values) => {
    handleLogUp();
    setSuccess(true);
    console.log("Success:", values);
  };

  const onFinishFailed = (errorInfo) => {
    setSuccess(false);
    message.error(`Vui lòng nhập đầy đủ thông tin!`);
    console.log("Failed:", errorInfo);
  };

  console.log("isSuccess:", isSuccess);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    if (name === "lastname") {
      setLastname(value);
    } else if (name === "firstname") {
      setFirstname(value);
    } else if (name === "username") {
      setUsername(value);
    } else if (name === "password") {
      setPassword(value);
    } else if (name === "confirmpassword") {
      setConfirmpassword(value);
    } else if (name === "email") {
      setEmail(value);
    }
  };

  const handleLogUp = async () => {
    try {
      const formData = new FormData();
      formData.append("firstname", firstname);
      formData.append("lastname", lastname);
      formData.append("username", username);
      formData.append("password", password);
      formData.append("confirmpassword", confirmpassword);
      formData.append("email", email);

      const response = await fetch("https://localhost:7139/api/User/register", {
        method: "POST",
        body: formData,
      });

      console.log("Response:", response);
      console.log("formData:", formData);

      if (!response.ok) {
        message.error(`Sign Up failed!`);
      } else {
        message.success(`Sign Up Successfully.`);
        navigate(`/sign_in`);
      }
    } catch (error) {
      console.error("Error sign up:", error);
    }
  };

  return (
    <div className="background">
      <Form
        layout="vertical"
        className="logup_form"
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
            fontSize: 24,
          }}
        >
          Đăng ký
        </Typography>
        <div className="divide_into_2cols">
          <Form.Item
            className="no_margin"
            label={<p className="label">Họ</p>}
            name="lastname"
            rules={[
              {
                validator: (_, value) => {
                  if (!value) {
                    return Promise.reject("Xin vui lòng điền Họ!");
                  }
                  if (/^[^0-9]+$/i.test(value)) {
                    return Promise.resolve();
                  } else {
                    return Promise.reject("Họ không thể chứa các ký tự số!");
                  }
                },
              },
            ]}
          >
            <Input
              size="large"
              placeholder="Họ"
              name="lastname"
              value={lastname}
              onChange={handleInputChange}
            />
          </Form.Item>
          <Form.Item
            className="no_margin"
            label={<p className="label">Tên</p>}
            name="firstname"
            rules={[
              {
                validator: (_, value) => {
                  if (!value) {
                    return Promise.reject("Xin vui lòng điền Tên!");
                  }
                  if (/^[^0-9]+$/i.test(value)) {
                    return Promise.resolve();
                  } else {
                    return Promise.reject("Tên không thể chứa các ký tự số!");
                  }
                },
              },
            ]}
          >
            <Input
              size="large"
              placeholder="Tên"
              name="firstname"
              value={firstname}
              onChange={handleInputChange}
            />
          </Form.Item>
        </div>
        <Form.Item
          className="no_margin red_star"
          label={<p className="label">Tên đăng nhập</p>}
          name="username"
          rules={[
            {
              validator: (_, value) => {
                if (!value) {
                  return Promise.reject("Xin vui lòng nhập Tên đăng nhập!");
                }
                if (value.length < 5) {
                  return Promise.reject(
                    "Tên đăng nhập phải chứa ít nhất 6 kí tự!"
                  );
                } else if (/^[^0-9][a-zA-Z0-9]+$/.test(value)) {
                  return Promise.resolve();
                } else {
                  return Promise.reject("Kí tự đầu không được là chữ số!");
                }
              },
            },
          ]}
        >
          <Input
            size="large"
            placeholder="Tên đăng nhập"
            name="username"
            value={username}
            onChange={handleInputChange}
          />
        </Form.Item>
        <Form.Item
          className="no_margin red_star"
          label={<p className="label">Mật khẩu</p>}
          name="password"
          rules={[
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
              message: "Xin vui lòng xác nhận mật khẩu của bạn!",
            },
            ({ getFieldValue }) => ({
              validator(_, value) {
                if (!value || getFieldValue("password") === value) {
                  return Promise.resolve();
                }
                return Promise.reject(
                  new Error("Mật khẩu mới mà bạn vừa nhập không khớp!")
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
        <Form.Item
          className="no_margin"
          label={<p className="label">Email</p>}
          name="email"
          rules={[
            {
              type: "email",
              message: "Xin vui lòng điền Email!",
            },
            {
              required: true,
              message: "Xin vui lòng điền Email!",
            },
          ]}
        >
          <Input
            size="large"
            placeholder="Email"
            name="email"
            value={email}
            onChange={handleInputChange}
          />
        </Form.Item>
        <Form.Item className="no_margin">
          <ConfigProvider
            theme={{
              token: {
                colorBgContainer: "rgba(0, 52, 101, 1)",
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
              Đăng ký
            </Button>
          </ConfigProvider>
        </Form.Item>
      </Form>
    </div>
  );
}

export default Logup;
