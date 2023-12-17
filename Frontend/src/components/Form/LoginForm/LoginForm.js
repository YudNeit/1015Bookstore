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

function Login() {
  return (
    <div className="background">
      <Form
        layout="vertical"
        className="login_form"
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
          Đăng nhập
        </Typography>
        <Form.Item
          className="no_margin"
          label={<p className="label">Tên đăng nhập</p>}
          name="username"
          rules={[
            {
              required: true,
              message: "Please input your username!",
            },
          ]}
        >
          <Input size="large" placeholder="Tên đăng nhập/Email" />
        </Form.Item>

        <Form.Item
          className="no_margin"
          label={<p className="label">Mật khẩu</p>}
          name="password"
          rules={[
            {
              required: true,
              message: "Please input your password!",
            },
          ]}
        >
          <Input.Password size="large" placeholder="Mật khẩu" />
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
              Đăng nhập
            </Button>
          </ConfigProvider>
        </Form.Item>
        <div className="functions">
          <Form.Item className="no_margin">
            <a
              className="login-form-forgot"
              href="http://localhost:3000/forgot_password"
              style={{ color: "#1f9d60", fontSize: "12px" }}
            >
              Quên mật khẩu
            </a>
          </Form.Item>

          <Form.Item className="no_margin">
            <span style={{ color: "#1f9d60", fontSize: "12px" }}>
              Bạn chưa có tài khoản?{" "}
            </span>
            <a
              className="logup-form"
              href="http://localhost:3000/sign_up"
              style={{ color: "#CF4330", fontSize: "12px" }}
            >
              Đăng ký tại đây
            </a>
          </Form.Item>
        </div>
      </Form>
    </div>
  );
}

export default Login;
