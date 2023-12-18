import { Typography } from "antd";
import "../style.css";
import { Button, Form, Input, ConfigProvider } from "antd";
const { Title } = Typography;
const onFinish = (values) => {
  console.log("Success:", values);
};

const onFinishFailed = (errorInfo) => {
  console.log("Failed:", errorInfo);
};

function Logup() {
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
                    return Promise.reject("Please input your username!");
                  }
                  if (/^[^0-9]+$/i.test(value)) {
                    return Promise.resolve();
                  } else {
                    return Promise.reject("Name is not include number");
                  }
                },
              },
            ]}
          >
            <Input size="large" placeholder="Họ" />
          </Form.Item>
          <Form.Item
            className="no_margin"
            label={<p className="label">Tên</p>}
            name="firstname"
            rules={[
              {
                validator: (_, value) => {
                  if (!value) {
                    return Promise.reject("Please input your username!");
                  }
                  if (/^[^0-9]+$/i.test(value)) {
                    return Promise.resolve();
                  } else {
                    return Promise.reject("Name is not include number");
                  }
                },
              },
            ]}
          >
            <Input size="large" placeholder="Tên" />
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
                  return Promise.reject("Please input your username!");
                }
                if (value.length < 5) {
                  return Promise.reject(
                    "Username must be bigger than 5 character"
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
          <Input size="large" placeholder="Tên đăng nhập" />
        </Form.Item>
        <Form.Item
          className="no_margin red_star"
          label={<p className="label">Mật khẩu</p>}
          name="password"
          rules={[
            {
              validator: (_, value) => {
                if (!value) {
                  return Promise.reject("Please input your password!");
                }
                if (value.length <= 6) {
                  return Promise.reject(
                    "Password should bigger than 6 characters"
                  );
                } else return Promise.resolve();
              },
            },
          ]}
        >
          <Input.Password size="large" placeholder="Mật khẩu" />
        </Form.Item>
        <Form.Item
          className="no_margin"
          label={<p className="label">Xác nhận mật khẩu</p>}
          name="verifypassword"
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
          <Input.Password size="large" placeholder="Xác nhận mật khẩu" />
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
          <Input size="large" placeholder="Email" />
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
