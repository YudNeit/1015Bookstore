import { Button, Row, Col, List } from "antd";
import React from "react";
import { IoLocationSharp } from "react-icons/io5";

const data = [
  {
    title: "LLDT",
    phone: "0946854546",
    location:
      "Ktx Đại Học Quốc Gia Tp. Hồ Chí Minh, Khu A, Phường Đông Hòa, Thành Phố Dĩ An, Bình Dương",
  },
];

function CheckoutPage() {
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
              <List.Item.Meta
                title={item.title}
                phone={<div>{item.phone}</div>}
                location={<div>{item.location}</div>}
                changebtn={<Button>Thay Đổi</Button>}
              />
            </List.Item>
          )}
        ></List>
      </div>
    </div>
  );
}

export default CheckoutPage;
