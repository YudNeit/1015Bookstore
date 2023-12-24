import React, { useState, useEffect } from "react";
import { Button, Card, Col, Row } from "antd";
import MenuSlide from "../../components/MenuSlide";
import { useNavigate } from "react-router-dom";
import { fetchProductData } from "../../components/Data/api";

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
      <MenuSlide onMenuSelect={handleMenuSelect} />
      {/* Display filtered data */}
      {items.map((item) => (
        <Row gutter={16} key={item.title}>
          <Col span={8}>
            <Card
              hoverable
              style={{ width: 240 }}
              cover={
                <img
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
              <Meta title={item.name} />
              <div>Price: {item.price}</div>
              <Button>Add to cart</Button>
            </Card>
          </Col>
        </Row>
      ))}
    </div>
  );
}

export default MainPage;
