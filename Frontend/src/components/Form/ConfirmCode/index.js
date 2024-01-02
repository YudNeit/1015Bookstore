import { Typography, message } from "antd";
import { Button, Form, Input, ConfigProvider } from "antd";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const { Title } = Typography;

function ConfirmCodeForm() {
  const navigate = useNavigate();
  const [confirmcode, setConfirmcode] = useState("");
  const [isSuccess, setSuccess] = useState(false);

  useEffect(() => {}, []);

  const onFinish = (values) => {
    handleConfirmClick();
    setSuccess(true);
    console.log("Success:", values);
  };

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

  const onFinishFailed = (errorInfo) => {
    setSuccess(false);
    message.error(`Vui lòng nhập đầy đủ thông tin!`);
    console.log("Failed:", errorInfo);
  };
  console.log("isSuccess:", isSuccess);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    if (name === "confirmcode") {
      setConfirmcode(value);
    }
  };

  const handleConfirmClick = async () => {
    try {
      const apiUrl =
        "https://localhost:7139/api/User/confirmCodeforgotpassword";
      const jwtToken = getCookie("forgotToken");

      const data = {
        token: jwtToken,
        code: confirmcode,
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
        if (response.status === 400) {
          message.error("Vui lòng nhập mã xác nhận!");
        } else {
          try {
            const error = await response.text();
            if (error) {
              message.error(`${error}`);
            }
          } catch (error) {
            message.error("Confirm Code is not valid.");
          }
        }
      } else {
        message.success("Confirm Code is successful.");
        navigate(`/change_password`);
      }
    } catch (error) {
      console.error("Error Confirmation Code:", error);
      message.error("Confirmation Code failed. Please try again later.");
    }
  };

  return (
    <div className="background">
      <Form
        layout="vertical"
        className="confirmcode_form"
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
            Mã xác nhận
          </Typography>
        </div>
        <Form.Item
          className="no_margin"
          label={<p className="label">Confirmcode</p>}
          name="comfirm"
          rules={[
            {
              required: true,
              message: "Please input confirm code!",
            },
          ]}
        >
          <Input
            size="large"
            placeholder="Confirmcode"
            name="confirmcode"
            value={confirmcode}
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
              Xác nhận
            </Button>
          </ConfigProvider>
        </Form.Item>
      </Form>
    </div>
  );
}

export default ConfirmCodeForm;
