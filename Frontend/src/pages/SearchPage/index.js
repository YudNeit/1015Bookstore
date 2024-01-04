import React, { useEffect, useState } from "react";
import { Card, Col, Row } from "antd"; 
import { useNavigate } from "react-router-dom";
import MenuSlide from "../../components/MenuSlide";

const SearchPage = () => {
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();
  const searchValue = localStorage.getItem("datasearch");
  const [selectedMenu, setSelectedMenu] = useState(null);

  useEffect(() => {

    const fetchData = async () => {
      try {
        setLoading(true);

        const response = await fetch(
          `https://localhost:7139/api/Product/public-paging-keyword?sKeyword=${searchValue}&pageindex=1&pagesize=100`
        );

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        console.log("API Response:", data);

        setItems(data.items);
      } catch (error) {
        console.error("API Error:", error);
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
      <div className="card_container">
        {items.map((item) => (
          <Card
            key={item.sProduct_name}
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
              <span className="book_title">{item.sProduct_name}</span>
              <span className="book_price">{item.vProduct_price}đ</span>
            </div>
          </Card>
        ))}
      </div>
    </div>
  );
};

export default SearchPage;
