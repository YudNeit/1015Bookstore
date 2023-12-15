import { Typography } from "antd";
import "./style.css";
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
        className="loginForm"
        // name="basic"
        // labelCol={{
        //   span: 8,
        // }}
        // wrapperCol={{
        //   span: 16,
        // }}
        // style={{
        //   maxWidth: 600,
        //   textAlign: "center",
        // }}
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
            fontSize: 30,
            color: "white",
            marginTop: 0,
            marginBottom: 10,
          }}
        >
          Đăng nhập
        </Typography>
        <Form.Item
          label={<p className="label">Username</p>}
          name="username"
          rules={[
            {
              required: true,
              message: "Please input your username!",
            },
          ]}
        >
          <Input size="large" placeholder="Username" />
        </Form.Item>

        <Form.Item
          label={<p className="label">Password</p>}
          name="password"
          rules={[
            {
              required: true,
              message: "Please input your password!",
            },
            
          ]}
        >
          <Input.Password size="large" placeholder="Password" />
        </Form.Item>

        <Form.Item>
          <a
            className="login-form-forgot"
            href="http://localhost:3000/forgot_password"
          >
            Forgot password
          </a>
          <Form.Item>
            Bạn chưa có tài khoản?
            <a className="logup-form" href="http://localhost:3000/sign_up">
              Đăng ký tại đây
            </a>
          </Form.Item>
        </Form.Item>

        <Form.Item>
          <ConfigProvider
            theme={{
              token: {
                colorBgContainer: "rgba(0, 52, 101, 1)",
                colorBorder: "none",
              },
            }}
          >
            <Button
              style={{
                fontWeight: "bold",
                color: "white",
                backgroundColor: "#30CF82",
              }}
              block
              size="large"
              type="default"
              htmlType="submit"
            >
              Sign in
            </Button>
          </ConfigProvider>
        </Form.Item>
      </Form>
    </div>
  );
}

export default Login;
