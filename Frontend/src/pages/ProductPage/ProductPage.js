import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Avatar, Button, Col, Image, InputNumber, List, Rate, Row } from "antd";
import { useCart } from "../../components/Context/CartContext";

const data = [
  {
    title: "Ant Design Title 1",
    description: "1234567890edfghjasvydasgbfklfjnldksjrl",
    rate: 2.5,
  },
  {
    title: "Ant Design Title 2",
    rate: 1,
  },
  {
    title: "Ant Design Title 3",
    description: "ydasgbfklfjnldksjr31231241455642342432141l",
    rate: 5,
  },
  {
    title: "Ant Design Title 4",
    description: "1hgjghj34534534534534534534ydasgbfklfjnldksjrl",
    rate: 3,
  },
];

function ProductPage() {
  const { addToCart } = useCart();
  const location = useLocation();
  const { state } = location;
  const item = state ? state.item : null;
  const navigate = useNavigate();
  const [quantity, setQuantity] = useState(1);

  useEffect(() => {
    // Scroll đến đầu trang khi component đã mount
    window.scrollTo(0, 0);
  }, []);

  const handleAddToCart = () => {
    const cartItem = {
      id: item.id,
      name: item.title,
      quantity: quantity,
      price: item.price,
      img: item.img,
    };
    addToCart(cartItem);
    // Thêm sản phẩm vào giỏ hàng (đây là nơi lưu trữ tạm thời, bạn có thể sử dụng Redux hoặc Context API để quản lý giỏ hàng toàn cục)

    // Đoạn mã dưới đây là để mô phỏng việc thêm vào giỏ hàng. Bạn cần thay thế nó với logic thực tế.
    console.log("Đã thêm vào giỏ hàng:", cartItem);
    setQuantity(1); // Đặt lại số lượng sau khi thêm vào giỏ hàng

    // (Tùy chọn) Chuyển hướng đến trang giỏ hàng sau khi thêm vào giỏ hàng
    navigate("/cart");
  };

  return (
    <div>
      {item && (
        <div>
          <Row>
            <Col md={4}>
              <Image src={item.img} alt={item.title} />
            </Col>
            <Col>
              <List>
                <List.Item>
                  <h3>{item.title}</h3>
                </List.Item>
                <List.Item>
                  <Rate disabled defaultValue={item.rate} />
                </List.Item>
                <List.Item>Price: {item.price}đ</List.Item>
                <List.Item>
                  Số lượng:{" "}
                  <InputNumber
                    min={1}
                    value={quantity}
                    onChange={setQuantity}
                  />
                </List.Item>
                <List.Item>
                  <Button onClick={handleAddToCart}>Thêm vào giỏ hàng</Button>
                  <Button>Mua Ngay</Button>
                </List.Item>
              </List>
            </Col>
          </Row>
          <Row>
            <Col>
              <List>
                <List.Item>
                  <h3>Thông tin sản phẩm</h3>
                </List.Item>
                <List.Item>Danh Mục: {item.category}</List.Item>
                <List.Item>Nhà xuất bản: {item.Nhaxuatban}</List.Item>
                <List.Item>Nhà cung cấp: {item.Nhacungcap}</List.Item>
                <List.Item>Tác giả: {item.Tacgia}</List.Item>
                <List.Item>
                  <h3>Mô tả sản phẩm</h3>
                </List.Item>
                <List.Item>{item.description}</List.Item>
              </List>
            </Col>
          </Row>
          <Row>
            <h3>Đánh giá sản phẩm</h3>
          </Row>
          <Row>
            <Col>
              <Row> "Biến +" trên 5 </Row>
              <Row>
                <Rate disabled defaultValue={5} />
              </Row>
            </Col>
            <Button>Tất cả</Button>
            <Col></Col>
            <Button>5*</Button>
            <Col></Col>
            <Button>4*</Button>
            <Col></Col>
            <Button>3*</Button>
            <Col></Col>
            <Button>2*</Button>
            <Col></Col>
            <Col>
              <Button>1*</Button>
            </Col>
          </Row>
          <Row>
            <List
              dataSource={data}
              renderItem={(item, index) => (
                <List.Item>
                  <List.Item.Meta
                    avatar={
                      <Avatar
                        src={`https://xsgames.co/randomusers/avatar.php?g=pixel&key=${index}`}
                      />
                    }
                    title={<div>{item.title}</div>}
                    description={
                      <div>
                        <Rate allowHalf disabled defaultValue={item.rate} />
                        {item.description}
                      </div>
                    }
                  />
                </List.Item>
              )}
            />
          </Row>
        </div>
      )}
    </div>
  );
}

export default ProductPage;
