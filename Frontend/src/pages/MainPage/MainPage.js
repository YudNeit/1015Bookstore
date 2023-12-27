import React, { useState, useEffect } from "react";
import { Button, Card, Col, Row } from "antd";
import MenuSlide from "../../components/MenuSlide";
import { useNavigate } from "react-router-dom";
import { fetchProductData } from "../../components/Data/api";
import "./MainPage.css";
import { floatButtonPrefixCls } from "antd/es/float-button/FloatButton";

const { Meta } = Card;

function MainPage() {
  const navigate = useNavigate();
  const [selectedMenu, setSelectedMenu] = useState(null);
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

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

  useEffect(() => {
    const fetchData = async () => {
      try {
        const jwtToken = getCookie("accessToken");
        const data = await fetchProductData(jwtToken);
        setItems(data);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleMenuSelect = (selectedValue) => {
    setSelectedMenu(selectedValue);
    navigate(`/${selectedValue}`);
  };

  const handleCardClick = (item) => {
    console.log("Card clicked:", item);
    navigate(`/product-detail/${item.id}`, { state: { item } });
  };

  return (
    <div>
      <Row className="title_bar">
        <Col>
          <MenuSlide
            style={{ backgroundColor: "#30cf82" }}
            onMenuSelect={handleMenuSelect}
          />
        </Col>
        <Col offset={1} style={{ borderRadius: "30px" }}>
          <h2 className="page_title">DANH MỤC SẢN PHẨM</h2>
        </Col>
      </Row>
      <div className="cart_container">
        {items.map((item) => (
          <Card
            key={item.title}
            style={{
              border: "2px solid #ededed",
              display: "inline-block",
              margin: "0px 30px 30px 0px",
              padding: "10px 5px",
            }}
            hoverable
            cover={
              <img
                style={{ height: 300, width: 260 }}
                alt={item.name}
                src={
                  item.pathThumbnailImage == null
                    ? require(`../../assets/user-content/img_1.webp`)
                    : require(`../../assets/user-content/${item.pathThumbnailImage}`)
                }
              />
            }
            onClick={() => handleCardClick(item)}
          >
            <div className="flex_column">
              <span className="title">{item.name}</span>
              <span className="price">{item.price}đ</span>
              {/* <Button size="large">Add to cart</Button> */}
            </div>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default MainPage;
