import React, { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { IoLocationSharp } from "react-icons/io5";
import { useNavigate } from "react-router-dom";
import {
  Button,
  Row,
  List,
  Card,
  Typography,
  Select,
  Image,
  Modal,
  Input,
} from "antd";
import { message } from "antd";
import { Option } from "antd/es/mentions";

const { Paragraph } = Typography;

const data = [
  {
    name: "LLDT",
    phone: "0946854546",
    location:
      "Ktx Đại Học Quốc Gia Tp. Hồ Chí Minh, Khu A, Phường Đông Hòa, Thành Phố Dĩ An, Bình Dương",
  },
];

function CheckoutPage() {
  const navigate = useNavigate();
  const location = useLocation();
  const [items, setItems] = useState([]);
  const [order, setOrder] = useState([]);
  const [promotionalCode, setPromotionalCode] = useState("");
  const [voucherDiscount, setVoucherDiscount] = useState(0);
  const [shippingFee, setShippingFee] = useState(30000);
  const [showConfirmation, setShowConfirmation] = useState(false);
  const [isApply, setisApply] = useState(false);
  const [messageApi, contextHolder] = message.useMessage();
  const key = "updatable";
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
  const orderId = localStorage.getItem("orderId");
  const jwtToken = getCookie("accessToken");
  const userId = getCookie("userid");

  const fetchCheckOutData = async () => {
    try {
      const response = await fetch(
        `https://localhost:7139/api/Order/${orderId}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwtToken}`,
          },
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      const data = await response.json();
      setItems(data.orderdetails);
      setOrder(data);
    } catch (error) {
      console.error("Error fetching product data:", error);
      // Handle error, show a message, etc.
    }
  };

  useEffect(() => {
    fetchCheckOutData();
  }, []);

  const handleCheckVoucher = async () => {
    try {
      const response = await fetch(
        `https://localhost:7139/api/PromotionalCode/checkcode?stringcode=${promotionalCode}&user=${userId}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwtToken}`,
          },
        }
      );

      if (response.ok) {
        // Promotional code applied successfully
        message.success(`Promotional code was applied.`);
        setisApply(true);
      } else {
        // Promotional code application failed
        const errorData = await response.json();
        message.error(
          `Cannot apply promotional code. Error: ${errorData.message}`
        );
      }
    } catch (error) {
      console.error("Error applying promotional code:", error);
    }
  };

  const handleApplyVoucher = async () => {
    try {
      const apiUrl = `https://localhost:7139/api/PromotionalCode/getbycode/${promotionalCode}`;
      const response = await fetch(apiUrl, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${jwtToken}`,
        },
      });
      const data = await response.json();
      setVoucherDiscount(data.discount_rate);

      console.log(voucherDiscount); // In dữ liệu từ API ra console
    } catch (error) {
      console.error("Cannot check voucher:", error);
      throw error;
    }
  };

  const calculateTotalPrice = () => {
    return items.reduce((total, item) => total + item.price * item.quantity, 0);
  };

  let totalPrice = calculateTotalPrice();

  const calculateTotalPayment = () => {
    if (isApply) {
      totalPrice *= 1 - voucherDiscount / 100;
    } else {
      totalPrice = calculateTotalPrice();
    }

    totalPrice += shippingFee;

    return totalPrice;
  };

  const handleConfirmPayment = async () => {
    try {
      const formData = new FormData();
        formData.append("order_id", orderId);
        formData.append("name_reciver", order.name_reciver);
        formData.append("phone_reciver", order.phone_reciver);
        formData.append("address_reciver", order.address_reciver);
        formData.append("promotionalcode", promotionalCode);

      const response = await fetch("https://localhost:7139/api/Order/buy", {
        method: "PUT",
        headers: {
          Authorization: `Bearer ${jwtToken}`,
        },
        body: formData,
      });

      console.log("Response:", response);

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      message.success(`Order completed.`); 
      setShowConfirmation(false);
      navigate("/");
    } catch (error) {
      console.error("Error placing the order:", error);
    }

  };

  const handleCancelPayment = () => {
    // Handle cancellation of payment
    setShowConfirmation(false);
  };

  return (
    <div>
      <div className="location">
        <Row>
          <h3>
            <IoLocationSharp />
            Địa chỉ nhận hàng
          </h3>
        </Row>
        <List.Item>
          <div>
            Tên người dùng: <Input onChange={order.name_reciver} />
          </div>
        </List.Item>
        <List.Item>
          <div>
            Phone: <Input onChange={order.phone_reciver}/>
          </div>
        </List.Item>
        <List.Item>
          <div>
            Địa chỉ: <Input onChange={order.address_reciver} />
          </div>
        </List.Item>
      </div>
      <div>
        <List>
          <List.Item>
            <List.Item>
              <h3>Sản phẩm</h3>
            </List.Item>
            <List.Item>
              <div>Đơn giá</div>
            </List.Item>
            <List.Item>
              <div>Số lượng</div>
            </List.Item>
            <List.Item>
              <div>Thành tiền</div>
            </List.Item>
          </List.Item>
        </List>
        <div>
          {items.map((item) => (
            <Card key={item.cart_id}>
              <Row align="middle">
                <List.Item>
                  <Image
                    style={{
                      height: 50,
                    }}
                    src={
                      item.pathimage == null
                        ? require(`../../assets/user-content/img_1.webp`)
                        : require(`../../assets/user-content/${item.pathimage}`)
                    }
                    alt={item.name}
                  />
                </List.Item>
                <List.Item>{item.name}</List.Item>
                <List.Item>{item.price}đ</List.Item>
                <List.Item>{item.quantity}</List.Item>
                <List.Item>{item.price * item.quantity}đ</List.Item>
              </Row>
            </Card>
          ))}
        </div>
      </div>
      <div>
        <h3>Voucher</h3>
        <List.Item>
          <Input
            value={promotionalCode}
            onChange={(e) => setPromotionalCode(e.target.value)}
            disabled={isApply}
          />
        </List.Item>
        <Button onClick={handleCheckVoucher}>Check Code</Button>
        <Button onClick={handleApplyVoucher}>Áp dụng</Button>
      </div>
      <div>
        <List>
          <List.Item>
            <h3>Phương thức thanh toán</h3>
          </List.Item>
          <List.Item>Tổng tiền hàng: {totalPrice}đ</List.Item>
          <List.Item>Phí vận chuyển: {shippingFee}đ</List.Item>
          <List.Item>Tổng thanh toán: {calculateTotalPayment()}đ</List.Item>
          <List.Item>
            <Button onClick={() => setShowConfirmation(true)}>
              Thanh toán
            </Button>
          </List.Item>
        </List>
      </div>
      {contextHolder}
      <Modal
        visible={showConfirmation}
        onOk={handleConfirmPayment}
        onCancel={handleCancelPayment}
      >
        <p>Bạn có chắc muốn thanh toán?</p>
      </Modal>
    </div>
  );
}

export default CheckoutPage;
