import React, { useState, useEffect } from "react";
import {
  List,
  Card,
  Button,
  InputNumber,
  Checkbox,
  Image,
  message,
  Col,
  Row,
} from "antd";
import { useNavigate } from "react-router-dom";
import "./CartPage.css";

function CartPage() {
  const [selectedItems, setSelectedItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();
  const [items, setItems] = useState([]);

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
  const userId = getCookie("userid");
  const jwtToken = getCookie("accessToken");

  const fetchCartData = async (userId) => {
    try {
      if (!userId) {
        console.error("User ID not found in sessionStorage");
        return;
      }

      const response = await fetch(
        `https://localhost:7139/api/Cart/getcart/${userId}`,
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
      setItems(data);
    } catch (error) {
      console.error("Error fetching product data:", error);
      throw error; // Propagate the error to handle it in the calling code
    }
  };

  const removeCartItem = async (cartItemId) => {
    try {
      const response = await fetch(
        `https://localhost:7139/api/Cart/removecart/${cartItemId}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwtToken}`,
          },
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      await fetchCartData(userId);
    } catch (error) {
      console.error("Error removing cart item:", error);
    }
  };

  useEffect(() => {
    fetchCartData(userId);
  }, [setItems]);

  const handleCheckout = async () => {
    try {
      const selectedIds = items
        .filter((item) => selectedItems.includes(item.cart_id))
        .map((item) => item.cart_id);

      const formData = new FormData();
      selectedIds.forEach((id) => {
        formData.append("cart_ids", id);
      });
      formData.append("user_id", userId);
      console.log("Response:", formData);

      const response = await fetch("https://localhost:7139/api/Order", {
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

      const orderResponse = await response.json();
      const orderId = orderResponse.id;
      localStorage.setItem("orderId", orderId);
      navigate(`/checkout`);
      console.log("Order placed successfully!");
    } catch (error) {
      message.error("Vui lòng chọn sản phẩm bạn muốn thanh toán!");
      console.error("Error placing the order:", error);
    }
  };

  const handleCheckboxChange = (e, itemId) => {
    const { checked } = e.target;
    setSelectedItems((prevSelectedItems) => {
      if (checked) {
        return [...prevSelectedItems, itemId];
      } else {
        return prevSelectedItems.filter((id) => id !== itemId);
      }
    });
  };

  const handleCheckAllChange = () => {
    setSelectedItems((prevSelectedItems) => {
      return prevSelectedItems.length === items.length
        ? []
        : items.map((item) => item.cart_id);
    });
  };

  const handleCardClick = (item) => {
    console.log("Card clicked:", item);
    navigate(`/product-detail/${item.cart_id}`, { state: { item } });
  };

  const handleQuantityChange = async (itemId, value) => {
    try {
      const response = await fetch(
        `https://localhost:7139/api/Cart/updateamountcart/${itemId}/${value}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwtToken}`,
          },
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      // Fetch the updated cart data after updating the quantity
      await fetchCartData(userId);
    } catch (error) {
      message.error("Không thể đặt thêm sản phẩm này!");
      console.error("Error updating cart item quantity:", error);
    }
  };

  const handleRemoveItem = (cartItemId) => {
    removeCartItem(cartItemId);
  };

  const totalAmount = items.reduce(
    (total, item) =>
      selectedItems.includes(item.cart_id)
        ? total + item.price * item.amount
        : total,
    0
  );

  const totalQuantity = items.reduce(
    (total, item) =>
      selectedItems.includes(item.cart_id) ? total + item.amount : total,
    0
  );

  return (
    <div>
      <div>
        <div className="cartlist_item">
          <Col md={2} offset={0}>
            <Checkbox
              checked={items.length === selectedItems.length}
              onChange={handleCheckAllChange}
            >
              {items.length === selectedItems.length ? (
                <h3>Hủy chọn tất cả</h3>
              ) : (
                <h3>Chọn tất cả</h3>
              )}
            </Checkbox>
          </Col>
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
          <Col md={1}></Col>
        </div>
      </div>
      <div>
        {items.map((item) => (
          <Card key={item.cart_id}>
            <Row align="middle">
              <Col md={2} offset={0}>
                <Checkbox
                  checked={selectedItems.includes(item.cart_id)}
                  onChange={(e) => handleCheckboxChange(e, item.cart_id)}
                />
              </Col>
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
              <Col md={3}>
                <span> {item.price}đ</span>
              </Col>
              <Col md={3}>
                <div className="cartlist_item">
                  <Button
                    className="fit_content"
                    onClick={() => handleQuantityChange(item.cart_id, +1)}
                  >
                    +
                  </Button>

                  <span style={{ fontSize: "20px", margin: "0px 10px" }}>
                    {item.amount}
                  </span>

                  <Button
                    onClick={() => handleQuantityChange(item.cart_id, -1)}
                  >
                    -
                  </Button>
                </div>
              </Col>
              <Col md={3}>
                <span>{item.price * item.amount}đ</span>
              </Col>
              <Col md={1}>
                <Button onClick={() => handleRemoveItem(item.cart_id)}>
                  Xóa
                </Button>
              </Col>
            </Row>
          </Card>
        ))}
      </div>
      <div className="order_info_cover">
        <List>
          <List.Item>
            <h2>Thanh toán</h2>
          </List.Item>
          <List.Item>
            <span>Tổng số lượng: {totalQuantity}</span>
          </List.Item>
          <List.Item>
            <span>Tổng thanh toán: {totalAmount}đ</span>
          </List.Item>

          <List.Item>
            <Button
              size="large"
              className="cart_button"
              onClick={handleCheckout}
            >
              Mua Hàng
            </Button>
          </List.Item>
        </List>
      </div>
    </div>
  );
}

export default CartPage;
