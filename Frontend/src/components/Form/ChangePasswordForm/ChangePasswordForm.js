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

function ChangePassword() {
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
        >
          <Input.Password size="large" placeholder="Mật khẩu" />
        </Form.Item>

        <Form.Item
          className="no_margin"
          label={<p className="label">Xác nhận mật khẩu</p>}
          name="verifypassword"
        >
          <Input.Password size="large" placeholder="Xác nhận mật khẩu" />
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
