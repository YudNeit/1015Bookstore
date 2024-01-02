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
      const requestBody = {
        sUser_firstname: firstname,
        sUser_lastname: lastname,
        sUser_email: email,
        sUser_username: username,
        sUser_password: password,
        sUser_confirmpassword: confirmpassword,
      };

      const response = await fetch("https://localhost:7139/api/User/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestBody),
      });

      console.log("Response:", response);
      console.log("requestBody:", requestBody);

      if (!response.ok) {
        const errorResponse = await response.json();

        if (errorResponse.errors) {
          const usernameError = errorResponse.errors.sUser_username[0];
          message.error(`Sign Up failed: ${usernameError}`);
        } else {
          message.error("Sign Up failed. Please try again.");
        }
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
                required: true,
                message: "Please input your lastname!",
              },
              {
                validator: (_, value) => {
                  
                  if (/^[^0-9]+$/i.test(value)) {
                    return Promise.resolve();
                  } else {
                    return Promise.reject("Name is not include number");
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
                required: true,
                message: "Please input your firstname!",
              },
              {
                validator: (_, value) => {
                  if (/^[^0-9]+$/i.test(value)) {
                    return Promise.resolve();
                  } else {
                    return Promise.reject("Name is not include number");
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
              required: true,
              message: "Please input your username!",
            },
            {
              validator: (_, value) => {
                if (value.length < 6) {
                  return Promise.reject(
                    "Username must be bigger than 6 character"
                  );
                } else if (/^[^0-9][a-zA-Z0-9]+$/.test(value)) {
                  return Promise.resolve();
                } else {
                  return Promise.reject("Fist character must not be number");
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
              required: true,
              message: "Please input your password!",
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
        <Form.Item
          className="no_margin"
          label={<p className="label">Email</p>}
          name="email"
          rules={[
            {
              type: "email",
              message: "The input is not valid E-mail!",
            },
            {
              required: true,
              message: "Please input your E-mail!",
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
