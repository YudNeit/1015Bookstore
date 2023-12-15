import React, { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { IoLocationSharp } from "react-icons/io5";
import { useNavigate } from "react-router-dom";
import { useCart } from "../../components/Context/CartContext";
import {
  Button,
  Row,
  List,
  Card,
  Typography,
  Select,
  Image,
  Modal,
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
  const { removeFromCart } = useCart();
  const { selectedItems } = location.state || [];
  const [editableStr, setEditableStr] = useState();
  const [voucherCode, setVoucherCode] = useState("");
  const [appliedVoucher, setAppliedVoucher] = useState("");
  const [voucherDiscount, setVoucherDiscount] = useState(0);
  const [isVoucherUsed, setIsVoucherUsed] = useState(false);
  const [showConfirmation, setShowConfirmation] = useState(false);
  const [selectedItemsData, setSelectedItemsData] = useState([]);
  const [messageApi, contextHolder] = message.useMessage();
  const key = "updatable";
  const shippingFee = 30000;

  useEffect(() => {
    setSelectedItemsData(selectedItems || []);
  }, [selectedItems]);

  const calculateTotalPrice = () => {
    return selectedItemsData.reduce(
      (total, item) => total + parseFloat(item.price) * item.quantity,
      0
    );
  };

  const handleApplyVoucher = () => {
    if (voucherCode === "1") {
      if (isVoucherUsed) {
        // Voucher has already been used
        message.error("Only apply one voucher.");
        return;
      }
      setAppliedVoucher("1");
      setVoucherDiscount(0.1); // 10% discount
      setIsVoucherUsed(true);
    } else if (voucherCode === "2") {
      if (isVoucherUsed) {
        // Voucher has already been used
        message.error("Only apply one voucher.");
        return;
      }
      setAppliedVoucher("2");
      setVoucherDiscount(0.2); // 20% discount
      setIsVoucherUsed(true);
    } else {
      // Invalid voucher code
      message.error("Invalid voucher code");
    }
  };

  const calculateTotalPayment = () => {
    let totalPrice = calculateTotalPrice();

    // Apply voucher discount if a valid voucher is applied
    if (appliedVoucher) {
      totalPrice *= 1 - voucherDiscount;
    }

    totalPrice += shippingFee;

    return totalPrice;
  };
  const handleRemoveItem = (itemId) => {
    removeFromCart(itemId);
  };

  const handleConfirmPayment = () => {
    messageApi.open({
      key,
      type: "loading",
      content: "Loading...",
    });
    setTimeout(() => {
      messageApi.open({
        key,
        type: "success",
        content: "Đã thanh toán",
        duration: 2,
      });
    }, 1000);
    setShowConfirmation(false);
    handleRemoveItem(selectedItems);
    navigate("/");
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
        <List
          dataSource={data}
          renderItem={(item) => (
            <List.Item>
              <List.Item>{<div>Tên người dùng: {item.name}</div>}</List.Item>
              <List.Item>{<div>Phone: {item.phone}</div>}</List.Item>
              <List.Item>
                {
                  <Paragraph editable={{ onChange: setEditableStr }}>
                    {item.location}
                  </Paragraph>
                }
              </List.Item>
            </List.Item>
          )}
        ></List>
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
        <List
          dataSource={selectedItemsData}
          renderItem={(item) => (
            <List.Item>
              <Card key={item.id}>
                <Row align="middle">
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
                  <List.Item>{item.quantity}</List.Item>
                  <List.Item>{item.price * item.quantity}đ</List.Item>
                </Row>
              </Card>
            </List.Item>
          )}
        ></List>
      </div>
      <div>
        <h3>Voucher</h3>
        <Select
          style={{ width: 200 }}
          placeholder="Chọn mã giảm giá"
          onChange={(value) => setVoucherCode(value)}
        >
          <Option value="1">Discount 10%</Option>
          <Option value="2">Discount 20%</Option>
        </Select>
        <Button onClick={handleApplyVoucher}>Áp dụng</Button>
        {appliedVoucher && <div>Đã áp dụng voucher: {appliedVoucher}</div>}
      </div>
      <div>
        <List>
          <List.Item>
            <h3>Phương thức thanh toán</h3>
          </List.Item>
          <List.Item>Tổng tiền hàng: {calculateTotalPrice()}đ</List.Item>
          <List.Item>Phí vận chuyển: 30000đ</List.Item>
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
