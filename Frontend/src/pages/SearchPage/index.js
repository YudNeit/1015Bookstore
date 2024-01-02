// SearchPage.js

import React, { useEffect, useState } from "react";
import SearchBar from "../../components/SearchBar";
import { Card } from "antd"; // Assuming you are using Ant Design Card component
import { useNavigate } from "react-router-dom";

const SearchPage = () => {
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();
  const searchValue = localStorage.getItem("datasearch");
  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);

        const response = await fetch(
          `https://localhost:7139/api/Product/public-getbykeyword?sKeyword=${searchValue}`
        );

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        console.log("API Response:", data);

        setItems(data);
      } catch (error) {
        console.error("API Error:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleCardClick = (item) => {
    console.log("Card clicked:", item);
    navigate(`/product-detail/${item.iProduct_id}`, { state: { item } });
  };

  return (
    <div>
      <div className="cart_container">
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
              <span className="title">{item.sProduct_name}</span>
              <span className="price">{item.vProduct_price}đ</span>
            </div>
          </Card>
        ))}
      </div>
    </div>
  );
};

export default SearchPage;