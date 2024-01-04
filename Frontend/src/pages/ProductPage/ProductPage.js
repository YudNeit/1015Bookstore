import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import {
  Avatar,
  Button,
  Col,
  Image,
  InputNumber,
  List,
  Rate,
  Row,
  message,
} from "antd";
import "../stylePage.css";
import { ShoppingCartOutlined } from "@ant-design/icons";

const data = [
  {
    title: "Ant Design Title 1",
    description:
      "1234567890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvyd67890edfghjasvydasgbfklfjnldksjrl",
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
    window.scrollTo(0, 0);
  }, []);

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
  const jwtToken = getCookie("accessToken");
  const userId = getCookie("userid");

  console.log(item);

  const handleAddToCart = async () => {
    setAmount(1); // Đặt lại số lượng sau khi thêm vào giỏ hàng
    try {
      const data = {
        iProduct_id: item.iProduct_id,
        iProduct_amount: amount,
      };
      console.log(data);
      const response = await fetch(
        `https://localhost:7139/api/Cart/set?gUser_id=${userId}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwtToken}`,
          },
          body: JSON.stringify(data),
        }
      );
      console.log(response);
      if (response.ok) {
        navigate(`/cart`);
        console.log("Item added to the cart in the database");
      } else {
        const error = await response.text();
        if (error) {
          message.error(`${error}`);
        }
        console.error("Failed to add item to the cart in the database");
      }
    } catch (error) {
      message.error("Vui lòng đăng nhập!");
      console.error("Error adding item to the cart:", error);
    }
  };

  return (
    <div>
      {item && (
        <div>
          <Row className="pp_white_bg">
            <Col md={5} offset={1} className="image_column">
              <Image
                src={
                  item.sImage_pathThumbnail == null
                    ? require(`../../assets/user-content/img_1.webp`)
                    : require(`../../assets/user-content/${item.sImage_pathThumbnail}`)
                }
                alt={item.sProduct_name}
              />
            </Col>
            <Col md={14} offset={1} className="shortdetail_column">
              <List className="detail_list">
                <List.Item>
                  <h1>{item.sProduct_name}</h1>
                </List.Item>
                <List.Item className="pp_rate">
                  <span className="green rate_num">
                    {item.dProduct_start_count}
                  </span>
                  <Rate
                    className="green rate_star"
                    disabled
                    defaultValue={item.dProduct_start_count}
                  />
                </List.Item>
                <List.Item>
                  <span className="price">{item.vProduct_price}đ</span>
                </List.Item>
                <List.Item className="pp_amount">
                  <span>Số lượng:</span>
                  <InputNumber
                    className="amount_box"
                    min={1}
                    value={amount}
                    onChange={setAmount}
                  />
                </List.Item>
                <List.Item>
                  <Button
                    className="addtocart_button"
                    size="large"
                    onClick={handleAddToCart}
                  >
                    <ShoppingCartOutlined />
                    Thêm vào giỏ hàng
                  </Button>
                </List.Item>
              </List>
            </Col>
          </Row>
          <Row className="pp_padding pp_white_bg">
            <Col className="productdetail">
              <List>
                <List.Item>
                  <h2>Thông tin sản phẩm</h2>
                </List.Item>
                <List.Item style={{ fontSize: "15px", color: "#8c8c8c" }}>
                  Danh Mục: {item.category}
                </List.Item>
                <List.Item style={{ fontSize: "15px", color: "#8c8c8c" }}>
                  Nhà xuất bản: {item.sProduct_brand}
                </List.Item>
                <List.Item style={{ fontSize: "15px", color: "#8c8c8c" }}>
                  Nhà cung cấp: {item.sProduct_supplier}
                </List.Item>
                <List.Item style={{ fontSize: "15px", color: "#8c8c8c" }}>
                  Tác giả: {item.sProduct_author}
                </List.Item>
                <List.Item>
                  <h2>Mô tả sản phẩm</h2>
                </List.Item>
                <List.Item style={{ fontSize: "16px", color: "#8c8c8c" }}>
                  {item.sProduct_description}
                </List.Item>
              </List>
            </Col>
          </Row>
          <Col className="pp_padding pp_white_bg">
            <Row className="review_bar">
              <Row>
                <h2 className="review_title">Đánh giá sản phẩm</h2>
              </Row>
              <Row className="review_proportion">
                <Col>
                  <Row className="rate_proportion">
                    <span className="proportion_myrate green">3</span>
                    <span className="proportion_allrate green">trên 5</span>
                  </Row>
                  <Row>
                    <Rate className="green" defaultValue={3} />
                  </Row>
                </Col>
                <Col className="rate_filter">
                  <Button className="rate_filter_button">Tất cả</Button>
                  <Button className="rate_filter_button">5 sao</Button>
                  <Button className="rate_filter_button">4 sao</Button>
                  <Button className="rate_filter_button">3 sao</Button>
                  <Button className="rate_filter_button">2 sao</Button>
                  <Button className="rate_filter_button">1 sao</Button>
                </Col>
              </Row>
            </Row>
            <Row>
              <List
                className="user_review_list"
                dataSource={data}
                renderItem={(item, index) => (
                  <List.Item>
                    <List.Item.Meta
                      avatar={
                        <Avatar
                          className="user_avatar"
                          src={`https://xsgames.co/randomusers/avatar.php?g=pixel&key=${index}`}
                        />
                      }
                      title={<div>{item.title}</div>}
                      description={
                        <div className="user_review_description">
                          <Rate
                            className="green"
                            style={{ fontSize: "15px" }}
                            allowHalf
                            disabled
                            defaultValue={item.rate}
                          />
                          <br></br>
                          <span style={{ fontSize: "10px", color: "#8c8c8c" }}>
                            {item.description}
                          </span>
                        </div>
                      }
                    />
                  </List.Item>
                )}
              />
            </Row>
          </Col>
        </div>
      )}
    </div>
  );
}

export default ProductPage;
