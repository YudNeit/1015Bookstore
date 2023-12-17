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

function ForgotPassword() {
  return (
    <div className="background">
      <Form
        layout="vertical"
        className="forgotpassword_form"
        initialValues={{
          remember: true,
        }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        autoComplete="off"
      >
        <div>
          <Typography
            style={{
              fontWeight: "bolder",
              fontSize: 36,
            }}
          >
            Quên mật khẩu
          </Typography>
          <Typography
            style={{
              fontSize: 12,
              color: "#bebebe",
            }}
          >
            Có vẻ như có chuyện gì đó xãy ra với tài khoản của bạn. Hãy điền
            Email mà bạn đã tạo tài khoản để tiến hành khôi phục tài khoản!
          </Typography>
        </div>
        <Form.Item
          className="no_margin"
          label={<p className="label">Email</p>}
          name="email"
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
              Gửi mã xác nhận
            </Button>
          </ConfigProvider>
        </Form.Item>
      </Form>
    </div>
  );
}

export default ForgotPassword;
