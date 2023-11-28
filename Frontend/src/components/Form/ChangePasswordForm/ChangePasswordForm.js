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

function ChangePassword() {
  return (
    <div className="background">
      <Form
        layout="vertical"
        className="ChangePasswordForm"
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
          ChangePassword
        </Typography>
        <Form.Item
          label={<p className="label">Password</p>}
          name="password"
        >
          <Input.Password size="large" placeholder="Password" />
        </Form.Item>

        <Form.Item
          label={<p className="label">Verify Password</p>}
          name="verifypassword"
        >
          <Input.Password size="large" placeholder="Verify Password" />
        </Form.Item>
        <Form.Item
        // wrapperCol={{
        //   offset: 8,
        //   span: 16,
        // }}
        >
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
              Confirm
            </Button>
          </ConfigProvider>
        </Form.Item>
      </Form>
    </div>
  );
}

export default ChangePassword;
