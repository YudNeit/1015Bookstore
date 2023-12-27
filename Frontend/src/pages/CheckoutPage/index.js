import React, { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { IoLocationSharp } from "react-icons/io5";
import { useNavigate } from "react-router-dom";
import { Button, Row, Col, List, Card, Image, Modal, Input } from "antd";
import { message } from "antd";

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

  useEffect(() => {
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
        console.log(data);
        setItems(data.orderdetails);
        setOrder(data);
        return data;
      } catch (error) {
        console.error("Error fetching product data:", error);
      }
    };
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

      if (!response.ok) {
        if (response.status === 400) {
          message.error("Vui lòng nhập voucher!");
        } else {
          try {
            const error = await response.text();
            if (error) {
              message.error(`${error}`);
            }
          } catch (error) {
            // Handle non-JSON response or other errors
            message.error("Voucher cannot be applied! An error occurred.");
          }
        }
      } else {
        message.success("Voucher applied successfully.");
        setisApply(true);
      }
    } catch (error) {
      message.error(`Cannot apply promotional code  `);
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
      message.error("Voucher không tồn tại!");
      console.error("Cannot check voucher:", error);
    }
  };

  const calculateTotalPrice = () => {
    return items.reduce((total, item) => total + item.price * item.quantity, 0);
  };

  let totalPrice = calculateTotalPrice();

  const calculateTotalPayment = () => {
    if (voucherDiscount) {
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
      console.log(order.name_reciver);
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

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setOrder((prevOrder) => ({ ...prevOrder, [name]: value }));
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
            Tên người dùng:
            <Input
              name="name_reciver"
              value={order.name_reciver}
              onChange={handleInputChange}
            />
          </div>
        </List.Item>
        <List.Item>
          <div>
            Phone:{" "}
            <Input
              name="phone_reciver"
              value={order.phone_reciver}
              onChange={handleInputChange}
            />
          </div>
        </List.Item>
        <List.Item>
          <div>
            Địa chỉ:{" "}
            <Input
              name="address_reciver"
              value={order.address_reciver}
              onChange={handleInputChange}
            />
          </div>
        </List.Item>
      </div>
      <div>
        <List>
          <List.Item>
            <Col md={11} offset={0}>
              <h3>Sản phẩm</h3>
            </Col>
            <Col md={3}>
              <h3>Đơn giá</h3>
            </Col>
            <Col md={3}>
              <h3>Số lượng</h3>
            </Col>
            <Col md={3}>
              <h3>Thành tiền</h3>
            </Col>
          </List.Item>
        </List>
        <div>
          {items.map((item) => (
            <Card key={item.cart_id}>
              <Row align="middle">
                <Col md={11} offset={0}>
                  <div className="cartlist_item">
                    <Image
                      style={{
                        height: 120,
                        width: 100,
                      }}
                      src={
                        item.pathimage == null
                          ? require(`../../assets/user-content/img_1.webp`)
                          : require(`../../assets/user-content/${item.pathimage}`)
                      }
                      alt={item.product_name}
                    />
                    <span>{item.product_name}</span>
                  </div>
                </Col>
                <Col md={3}>{item.price}đ</Col>
                <Col md={3}>{item.quantity}</Col>
                <Col md={3}>{item.price * item.quantity}đ</Col>
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
        <Button onClick={handleCheckVoucher}>Áp dụng</Button>
        <Button onClick={handleApplyVoucher}>Check Code</Button>
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
            <Button
              onClick={() =>
                order.name_reciver &&
                order.phone_reciver &&
                order.address_reciver
                  ? setShowConfirmation(true)
                  : message.error(`Vui lòng nhập đầy đủ thông tin người nhận!`)
              }
            >
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
