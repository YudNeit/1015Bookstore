import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Avatar, Button, Col, Image, InputNumber, List, Rate, Row } from "antd";

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
  const location = useLocation();
  const { state } = location;
  const item = state ? state.item : null;
  const navigate = useNavigate();
  const [amount, setAmount] = useState(1);

  useEffect(() => {
    // Scroll đến đầu trang khi component đã mount
    window.scrollTo(0, 0);
  }, []);

  const getCookie = (cookieName) => {
    const cookies = document.cookie.split('; ');
    for (const cookie of cookies) {
      const [name, value] = cookie.split('=');
      if (name === cookieName) {
        return value;
      }
    }
    return null;
  };
  const jwtToken = getCookie('accessToken');
  const userId = getCookie('userid');
  
  console.log(item);

  const handleAddToCart = async () => {

    setAmount(1); // Đặt lại số lượng sau khi thêm vào giỏ hàng
    try {
      const response = await fetch(
        `https://localhost:7139/api/Cart/setcart?product_id=${item.id}&amount=${amount}&user_id=${userId}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${jwtToken}`,
          },
        }
      );
        console.log(response);
      if (response.ok) {
        // Handle the success case
        console.log("Item added to the cart in the database");

      } else {
        // Handle the error case
        console.error("Failed to add item to the cart in the database");
      }
    } catch (error) {
      console.error("Error adding item to the cart:", error);
    }
  };


  return (
    <div>
      {item && (
        <div>
          <Row>
            <Col md={4}>
              <Image src={
                    item.pathThumbnailImage == null
                      ? require(`../../assets/user-content/img_1.webp`)
                      : require(`../../assets/user-content/${item.pathThumbnailImage}`)
                  } alt={item.title} />
            </Col>
            <Col>
              <List>
                <List.Item>
                  <h3>{item.name}</h3>
                </List.Item>
                <List.Item>
                  <Rate disabled defaultValue={item.rate} />
                </List.Item>
                <List.Item>Price: {item.price}đ</List.Item>
                <List.Item>
                  Số lượng:{" "}
                  <InputNumber
                    min={1}
                    value={amount}
                    onChange={setAmount}
                  />
                </List.Item>
                <List.Item>
                  <Button onClick={handleAddToCart}>Thêm vào giỏ hàng</Button>
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
                <List.Item>Nhà xuất bản: {item.brand}</List.Item>
                <List.Item>Nhà cung cấp: {item.supplier}</List.Item>
                <List.Item>Tác giả: {item.author}</List.Item>
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
