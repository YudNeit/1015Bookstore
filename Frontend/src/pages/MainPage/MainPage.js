import React, { useState, useEffect } from "react";
import { Button, Card, Col, Rate, Row } from "antd";
import MenuSlide from "../../components/MenuSlide";
import { useNavigate } from "react-router-dom";
import { fetchProductData } from "../../components/Data/api";
import { floatButtonPrefixCls } from "antd/es/float-button/FloatButton";
import "./../styleMainPage.css";

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
    navigate(`/product-detail/${item.iProduct_id}`, { state: { item } });
  };

  return (
    <div>
      <h3 class="title-comm">
        <span class="title-holder">DANH MỤC SẢN PHẨM</span>
      </h3>
      <Row className="title_bar">
        <Col>
          <MenuSlide onMenuSelect={handleMenuSelect} />
        </Col>
      </Row>
      <div className="card_container">
        {items.map((item) => (
          <Card
            className="card_item"
            key={item.sProduct_name}
            hoverable
            bodyStyle={{ padding: "10px 24px" }}
            cover={
              <img
                className="mp_book_item_image"
                alt={item.sProduct_name}
                src={
                  item.sImage_pathThumbnail == null
                    ? require(`../../assets/user-content/img_1.webp`)
                    : require(`../../assets/user-content/${item.sImage_pathThumbnail}`)
                }
              />
            }
            onClick={() => handleCardClick(item)}
          >
            <div className="flex_column">
              <div className="title_start_container">
                <span className="book_title">{item.sProduct_name}</span>
                <Rate
                  disabled
                  className="book_star"
                  defaultValue={item.dProduct_start_count}
                />
              </div>
              <span className="book_price">
                {item.vProduct_price}
                <span
                  style={{
                    verticalAlign: "super",
                    fontSize: "10px",
                    textDecoration: "underline",
                    marginLeft: "2px",
                  }}
                >
                  đ
                </span>
              </span>
            </div>
          </Card>
        ))}
      </div>
    </div>
  );
}

export default MainPage;
