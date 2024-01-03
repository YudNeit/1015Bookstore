import React, { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { IoLocationSharp } from "react-icons/io5";
import { useNavigate } from "react-router-dom";
import { Button, Row, Col, List, Card, Image, Modal, Input } from "antd";
import { message } from "antd";

function HistoryOrderPage() {
  const [items, setItems] = useState([]);
  const [order, setOrder] = useState([]);
  const [shippingFee, setShippingFee] = useState(30000);

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
  const orderId = localStorage.getItem("orderhistoryId");
  const jwtToken = getCookie("accessToken");

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

  const calculateTotalPrice = () => {
    return items.reduce(
      (total, item) => total + item.vProduct_price * item.iProduct_amount,
      0
    );
  };

  let totalPrice = calculateTotalPrice();
  return (
    <div>
      <div className="location">
        <Row>
          <h3>
            <IoLocationSharp />
            Địa chỉ nhận hàng
          </h3>
        </Row>
        <List>
          <List.Item>Tên người dùng: {order.sOrder_name_receiver}</List.Item>
          <List.Item>Phone: {order.sOrder_phone_receiver}</List.Item>
          <List.Item>Địa chỉ: {order.sOrder_address_receiver}</List.Item>
        </List>
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
        <List.Item>{order.sPromoionalCode_code}</List.Item>
      </div>
      <List.Item>Tổng tiền hàng: {totalPrice}đ</List.Item>
      <List.Item>Phí vận chuyển: {shippingFee}đ</List.Item>
      <List.Item>Tổng thanh toán: {order.vOrder_total}đ</List.Item>
    </div>
  );
}

export default HistoryOrderPage;
