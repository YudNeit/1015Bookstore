import React, { useState, useEffect } from "react";
import { List, Row, Card, Button, InputNumber, Checkbox, Image } from "antd";
import { useNavigate } from "react-router-dom";

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
          method: "PUT", // Assuming that the API uses PUT for updating the quantity
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
    <div className="container">
      <div className="results">
        <List>
          <List.Item>
            <Checkbox
              checked={items.length === selectedItems.length}
              onChange={handleCheckAllChange}
            >
              {items.length === selectedItems.length
                ? "Hủy chọn tất cả"
                : "Chọn tất cả"}
            </Checkbox>
            <h3>Sản phẩm</h3>
            <h3>Đơn giá</h3>
            <h3>Số lượng</h3>
            <h3>Thành tiền</h3>
          </List.Item>
        </List>
      </div>
      <div>
        {items.map((item) => (
          <Card key={item.cart_id}>
            <Row align="middle">
              <Checkbox
                checked={selectedItems.includes(item.cart_id)}
                onChange={(e) => handleCheckboxChange(e, item.cart_id)}
              />
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
                  alt={item.product_name}
                />
              </List.Item>
              <List.Item>{item.product_name}</List.Item>
              <List.Item>{item.price}đ</List.Item>
              <List.Item>
                <Button onClick={() => handleQuantityChange(item.cart_id, +1)}>+</Button>
              </List.Item>
              <List.Item>{item.amount}</List.Item>
              <List.Item>
                <Button onClick={() => handleQuantityChange(item.cart_id, -1)}>-</Button>
              </List.Item>
              <List.Item>{item.price * item.amount}đ</List.Item>
              <List.Item>
                <Button onClick={() => handleRemoveItem(item.cart_id)}>
                  Xóa
                </Button>
              </List.Item>
            </Row>
          </Card>
        ))}
      </div>
      <div>
        <List>
          <List.Item>
            <h3>Thanh toán</h3>
          </List.Item>
          <List.Item>Tổng số lượng: {totalQuantity}</List.Item>
          <List.Item>Tổng thanh toán: {totalAmount}đ</List.Item>
          <List.Item>
            <Button onClick={handleCheckout}>Mua Hàng</Button>
          </List.Item>
        </List>
      </div>
    </div>
  );
}

export default CartPage;
