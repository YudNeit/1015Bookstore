import {
  Button,
  Row,
  Col,
  List,
  Typography,
  Card,
  Dropdown,
  message,
  Space,
} from "antd";
import React, { useState } from "react";
import { IoLocationSharp } from "react-icons/io5";

const { Paragraph } = Typography;

const data = [
  {
    name: "LLDT",
    phone: "0946854546",
    location:
      "Ktx Đại Học Quốc Gia Tp. Hồ Chí Minh, Khu A, Phường Đông Hòa, Thành Phố Dĩ An, Bình Dương",
  },
];

const datacart = [
  {
    name: "sach 1",
    dongia: "100.000đ",
    soluong: "1",
    thanhtien: "100.000đ",
  },
  {
    name: "sach 2",
    dongia: "200.000đ",
    soluong: "1",
    thanhtien: "200.000đ",
  },
  {
    name: "sach 3",
    dongia: "300.000đ",
    soluong: "1",
    thanhtien: "200.000đ",
  },
];

const items = [
  { key: "1", label: "discount 30%" },
  { key: "2", label: "discount 40%" },
  { key: "3", label: "discount 60%" },
];

const onClick = ({ key }) => {
  message.info(`Click on item ${key}`);
};

function CheckoutPage() {
  const [editableStr, setEditableStr] = useState();
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
            <List.Item>{<h3>Sản phẩm</h3>}</List.Item>
            <List.Item>{<div>đơn giá</div>}</List.Item>
            <List.Item>{<div>số lượng</div>}</List.Item>
            <List.Item>{<div>thành tiền</div>}</List.Item>
          </List.Item>
        </List>
        <List
          dataSource={datacart}
          renderItem={(item) => (
            <List.Item>
              <Card>
                <Row>
                  <List.Item>{<div>{item.name}</div>}</List.Item>
                  <List.Item>{<div>{item.dongia}</div>}</List.Item>
                  <List.Item>{<div>{item.soluong}</div>}</List.Item>
                  <List.Item>{<div>{item.thanhtien}</div>}</List.Item>
                </Row>
              </Card>
            </List.Item>
          )}
        ></List>
      </div>
      <div>
        <h3>Voucher</h3>
        <Dropdown
          menu={{
            items,
            onClick,
          }}
        >
          <a onClick={(e) => e.preventDefault()}>
            <Space>Hover me</Space>
          </a>
        </Dropdown>
      </div>
      <div>
        <List>
          <List.Item>
            <h3>Phương thức thanh toán</h3>
          </List.Item>
          <List.Item>Tổng tiền hàng: 100000đ</List.Item>
          <List.Item>Phí vận chuyển: 30000đ</List.Item>
          <List.Item>Tổng thanh toán: 130000đ</List.Item>
          <List.Item>
            <Button>Thanh toán</Button>
          </List.Item>
        </List>
      </div>
    </div>
  );
}

export default CheckoutPage;
