import React, { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { Button, Card, Col, Row, Pagination } from "antd";
import { useNavigate } from "react-router-dom";
import MenuSlide from "../../components/MenuSlide";

const { Meta } = Card;

const FilteredPage = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const pathName = location.pathname;
  const initialSelectedMenu = pathName.substring(1);
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [pagination, setPagination] = useState({
    current: 1,
    pageSize: 100,
    total: 0,
  });
  const [selectedMenu, setSelectedMenu] = useState(initialSelectedMenu);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);

        const response = await fetch(
          `https://localhost:7139/api/Product/public-paging-cate?lCate_ids=${selectedMenu}&pageindex=${pagination.current}&pagesize=${pagination.pageSize}`
        );

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        setItems(data);
      } catch (error) {
        setError(error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();

  }, [selectedMenu, pagination.current, pagination.pageSize]);

  const handleMenuSelect = (selectedValue) => {
    setSelectedMenu(selectedValue);
    window.location.reload();
  };

  const handleProductClick = (item) => {
    navigate(`/product-detail/${item.iProduct_id}`, { state: { item } });
  };

  return (
    <div style={{ display: "flex", flexDirection: "row" }}>
      <Col>
        <MenuSlide onMenuSelect={handleMenuSelect} />
      </Col>
      <Col>
        {loading && <p>Loading...</p>}
        {error && <p>Error: {error.message}</p>}
        {!loading && !error && Array.isArray(items) && items.length > 0 ? (
          items.map((item) => (
            <Card
              key={item.iProduct_id}
              style={{
                border: "1px solid black",
                display: "inline-block",
                margin: "0px 30px 30px 0px",
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
              onClick={() => handleProductClick(item)}
            >
              <Meta title={item.sProduct_name} />
              <div>Price: {item.vProduct_price}</div>
            </Card>
          ))
        ) : (
          <p>No items available.</p>
        )}
      </Col>
    </div>
  );
};

export default FilteredPage;
