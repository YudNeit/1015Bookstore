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

function Logup() {
  return (
    <div className="background">
      <Form
        layout="vertical"
        className="LogupForm"
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
          label={<p className="label">FirstName</p>}
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
          <Input size="large" placeholder="firstname" />
        </Form.Item>
        <Form.Item
          label={<p className="label">LastName</p>}
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
          <Input size="large" placeholder="lastname" />
        </Form.Item>
        <Form.Item
          label={<p className="label">Username</p>}
          name="username"
          rules={[
            {
              required: true,
              message: "Please input your username!",
            },
            {
              validator: (_, value) => {
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
            {
              validator: (_, value) =>
                value.length > 6
                  ? Promise.resolve()
                  : Promise.reject(
                      new Error("Password should bigger than 6 characters")
                    ),
            },
          ]}
        >
          <Input.Password size="large" placeholder="Password" />
        </Form.Item>
        <Form.Item
          label={<p className="label">Verify Password</p>}
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
          <Input.Password size="large" placeholder="Verify Password" />
        </Form.Item>
        <Form.Item
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

export default Logup;
