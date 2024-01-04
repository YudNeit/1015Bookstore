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
  const [showConfirmationPay, setShowConfirmationPay] = useState(false);
  const [isApply, setisApply] = useState(false);
  const [isCheck, setisCheck] = useState(false);
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
        setItems(data.lOrder_items);
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
      const apiUrl = `https://localhost:7139/api/PromotionalCode/checkcode?sPromotionalCode_code=${promotionalCode}&gUser_id=${userId}`;
      const response = await fetch(apiUrl, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${jwtToken}`,
        },
      });

      if (!response.ok) {
        try {
          const responseBody = await response.clone().text();
          const errorResponse = JSON.parse(responseBody);
          if (
            response.status === 400 &&
            errorResponse.errors &&
            errorResponse.errors.sPromotionalCode_code
          ) {
            // Check if status is 400 and sPromotionalCode_code field is required
            message.error("Need to enter Voucher");
          } else {
            const error = await response.text();
            message.error(`Check code failed: ${error}`);
          }
        } catch (parseError) {
          const error = await response.text();
          message.error(`${error}`);
        }
        setVoucherDiscount(0);
      } else {
        const data = await response.json();
        console.log(data);
        setVoucherDiscount(data.iPromotionalCode_discount_rate);
        message.success("Voucher is apply successful!");
        console.log(voucherDiscount);
      }
    } catch (error) {
      message.error("Voucher không tồn tại!");
      console.error("Cannot check voucher:", error);
    }
  };

  const calculateTotalPrice = () => {
    return items.reduce(
      (total, item) => total + item.vProduct_price * item.iProduct_amount,
      0
    );
  };

  let totalPrice = calculateTotalPrice();

  const calculateTotalPayment = () => {
    totalPrice *= 1 - voucherDiscount / 100;

    totalPrice += shippingFee;

    return totalPrice;
  };

  const handleConfirmPayment = async () => {
    try {
      const data = {
        iOrder_id: orderId,
        sOrder_name_receiver: order.sOrder_name_receiver,
        sOrder_phone_receiver: order.sOrder_phone_receiver,
        sOrder_address_receiver: order.sOrder_address_receiver,
        sPromotionalCode_code: promotionalCode,
      };
      console.log(data);
      const response = await fetch("https://localhost:7139/api/Order/buy", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${jwtToken}`,
        },
        body: JSON.stringify(data),
      });

      console.log("Response:", response);

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      message.success(`Order completed.`);
      setShowConfirmationPay(false);
      navigate("/");
    } catch (error) {
      console.error("Error placing the order:", error);
    }
  };

  const handleApplyVoucher = () => {
    if (isCheck) {
      setShowConfirmation(true);
    } else {
      message.error(`You need to check voucher before apply!`);
    }
  };
  const handleConfirmApplyVoucher = () => {
    setisApply(true);
    setShowConfirmation(false);
  };

  const handleCancelApplyVoucher = () => {
    setShowConfirmation(false);
  };

  const handleCancelPayment = () => {
    setShowConfirmationPay(false);
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
              name="sOrder_name_receiver"
              value={order.sOrder_name_receiver}
              onChange={handleInputChange}
            />
          </div>
        </List.Item>
        <List.Item>
          <div>
            Phone:{" "}
            <Input
              name="sOrder_phone_receiver"
              value={order.sOrder_phone_receiver}
              onChange={handleInputChange}
            />
          </div>
        </List.Item>
        <List.Item>
          <div>
            Địa chỉ:{" "}
            <Input
              name="sOrder_address_receiver"
              value={order.sOrder_address_receiver}
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
            <Card>
              <Row align="middle">
                <Col md={11} offset={0}>
                  <div className="cartlist_item">
                    <Image
                      style={{
                        height: 120,
                        width: 100,
                      }}
                      src={
                        item.sImage_path == null
                          ? require(`../../assets/user-content/img_1.webp`)
                          : require(`../../assets/user-content/${item.sImage_path}`)
                      }
                      alt={item.sProduct_name}
                    />
                    <span>{item.sProduct_name}</span>
                  </div>
                </Col>
                <Col md={3}>{item.vProduct_price}đ</Col>
                <Col md={3}>{item.iProduct_amount}</Col>
                <Col md={3}>{item.vProduct_price * item.iProduct_amount}đ</Col>
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
        <Button onClick={handleApplyVoucher} disabled={isApply}>
          Áp dụng
        </Button>
        <Button onClick={handleCheckVoucher} disabled={isApply}>
          Check Code
        </Button>
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
              onClick={() => {
                if (
                  order.sOrder_name_receiver &&
                  order.sOrder_phone_receiver &&
                  order.sOrder_address_receiver
                ) {
                  if (
                    order.sOrder_phone_receiver.length !== 10 ||
                    order.sOrder_phone_receiver[0] !== "0"
                  ) {
                    message.error(
                      "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0"
                    );
                  } else {
                    setShowConfirmationPay(true);
                  }
                } else {
                  message.error("Vui lòng nhập đầy đủ thông tin người nhận!");
                }
              }}
            >
              Thanh toán
            </Button>
          </List.Item>
        </List>
      </div>
      {contextHolder}
      <Modal
        visible={showConfirmationPay}
        onOk={handleConfirmPayment}
        onCancel={handleCancelPayment}
      >
        <p>Bạn có chắc muốn thanh toán?</p>
      </Modal>
      <Modal
        visible={showConfirmation}
        onOk={handleConfirmApplyVoucher}
        onCancel={handleCancelApplyVoucher}
      >
        <p>Bạn có chắc muốn áp dụng voucher?</p>
      </Modal>
    </div>
  );
}

export default CheckoutPage;
