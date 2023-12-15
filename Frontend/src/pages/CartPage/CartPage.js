import React, { useState } from "react";
import { List, Row, Card, Button, InputNumber, Checkbox, Image } from "antd";
import { useNavigate } from "react-router-dom";
import { useCart } from "../../components/Context/CartContext";

function CartPage() {
  const { cartItems, removeFromCart, updateCartItemQuantity } = useCart();
  const [selectedItems, setSelectedItems] = useState([]);
  const navigate = useNavigate();

  const handleCheckout = () => {
    // Filter out the selected items from the cartItems
    const selectedItemsForCheckout = cartItems.filter((item) =>
      selectedItems.includes(item.id)
    );

    // Now navigate to the checkout page with the selected items in the state
    navigate("/checkout", {
      state: { selectedItems: selectedItemsForCheckout },
    });
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
      return prevSelectedItems.length === cartItems.length
        ? []
        : cartItems.map((item) => item.id);
    });
  };

  const handleQuantityChange = (itemId, value) => {
    updateCartItemQuantity(itemId, value);
  };

  const handleRemoveItem = (itemId) => {
    removeFromCart(itemId);
  };

  const totalAmount = cartItems.reduce(
    (total, item) =>
      selectedItems.includes(item.id)
        ? total + item.price * item.quantity
        : total,
    0
  );

  const totalQuantity = cartItems.reduce(
    (total, item) =>
      selectedItems.includes(item.id) ? total + item.quantity : total,
    0
  );

  return (
    <div className="container">
      <div className="results">
        <List>
          <List.Item>
            <Checkbox
              checked={cartItems.length === selectedItems.length}
              onChange={handleCheckAllChange}
            >
              {cartItems.length === selectedItems.length
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
        {cartItems.map((item) => (
          <Card key={item.id}>
            <Row align="middle">
              <Checkbox
                checked={selectedItems.includes(item.id)}
                onChange={(e) => handleCheckboxChange(e, item.id)}
              />
              <List.Item>
                <Image
                  style={{
                    height: 50,
                  }}
                  src={item.img}
                  alt={item.title}
                />
              </List.Item>
              <List.Item>{item.name}</List.Item>
              <List.Item>{item.price}đ</List.Item>
              <List.Item>
                <InputNumber
                  min={1}
                  value={item.quantity}
                  onChange={(value) => handleQuantityChange(item.id, value)}
                />
              </List.Item>
              <List.Item>{item.price * item.quantity}đ</List.Item>
              <List.Item>
                <Button onClick={() => handleRemoveItem(item.id)}>Xóa</Button>
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
            <Button
  onClick={() => {
    handleCheckout(); // Add parentheses to invoke the function
  }}
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
