import React, { useState } from "react";
import { List, Row, Card, Button, InputNumber, Checkbox } from "antd";

const onChange = (e) => {
  console.log(`checked = ${e.target.checked}`);
};

const datacart = [
  {
    name: "sach 1",
    dongia: "100.000đ",
    soluong: "1",
    sotien: "100.000đ",
  },
  {
    name: "sach 2",
    dongia: "200.000đ",
    soluong: "1",
    sotien: "200.000đ",
  },
  {
    name: "sach 3",
    dongia: "300.000đ",
    soluong: "1",
    sotien: "200.000đ",
  },
];

function CartPage() {
  const [data, setData] = useState([
    {
      id: 1,
      name: "sach 1",
      dongia: "100.000đ",
      soluong: "1",
      sotien: "100.000đ",
    },
    {
      id: 2,
      name: "sach 2",
      dongia: "200.000đ",
      soluong: "1",
      sotien: "200.000đ",
    },
    {
      id: 3,
      name: "sach 3",
      dongia: "300.000đ",
      soluong: "1",
      sotien: "200.000đ",
    },
  ]);

  const [selectedItems, setSelectedItems] = useState([]);

  function checkboxHandler(e) {
    let isSelected = e.target.checked;
    let value = parseInt(e.target.value);

    if (isSelected) {
      setSelectedItems([...selectedItems, value]);
    } else {
      setSelectedItems((prevData) => {
        return prevData.filter((id) => {
          return id !== value;
        });
      });
    }
  }

  function checkAllHandler() {
    if (data.length === selectedItems.length) {
      setSelectedItems([]);
    } else {
      const postIds = data.map((item) => {
        return item.id;
      });

      setSelectedItems(postIds);
    }
  }
  return (
    <div className="container">
      <div className="results">
        <List>
          <List.Item>
            <List.Item>
              {
                <div>
                  <Checkbox onClick={checkAllHandler}>
                    {data.length === selectedItems.length
                      ? "Hủy chọn tất cả"
                      : "Chọn tất cả"}
                  </Checkbox>
                  <h3>Sản phẩm</h3>
                </div>
              }
            </List.Item>
            <List.Item>{<div>đơn giá</div>}</List.Item>
            <List.Item>{<div>số lượng</div>}</List.Item>
            <List.Item>{<div>thành tiền</div>}</List.Item>
          </List.Item>
        </List>
      </div>
      <div>
        {data.map((item, index) => (
          <div className="card" key={index}>
            <Card>
              <Row>
                <Checkbox
                  checked={selectedItems.includes(item.id)}
                  value={item.id}
                  onChange={checkboxHandler}
                />

                <List.Item>{<div>{item.name}</div>}</List.Item>
                <List.Item>{<div>{item.dongia}</div>}</List.Item>
                <List.Item>{<div>{item.soluong}</div>}</List.Item>
                <List.Item>{<div>{item.thanhtien}</div>}</List.Item>
              </Row>
            </Card>
          </div>
        ))}
      </div>
      <div>
      <List>
          <List.Item>
            <h3>Thanh toán</h3>
          </List.Item>
          <List.Item>Tổng thanh toán: 130000đ</List.Item>
          <List.Item>
            <Button>Mua Hàng</Button>
          </List.Item>
        </List>
      </div>
    </div>
  );
}

export default CartPage;
