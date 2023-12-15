// FilteredPage.js
import React from "react";
import { useLocation } from "react-router-dom";
import { items } from "../../components/Data";
import { Button, Card, Col, Row } from "antd";
import { useNavigate } from "react-router-dom";

const { Meta } = Card;
const FilteredPage = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const selectedMenu = location.pathname.substring(1); // Get the selected menu from the URL

  const filteredItems = items.filter((item) => item.category === selectedMenu);

  const handleProductClick = (item) => {
    // Chuyển hướng đến trang chi tiết sản phẩm và truyền thông tin sản phẩm qua state
    navigate(`/product-detail/${item.id}`, { state: { item } });
  };

  return (
    <div>
      {/* Display filtered data */}
      {filteredItems.map((item) => (
        <Row gutter={16} key={item.title}>
          <Col span={8}>
            <Card
              hoverable
              style={{
                width: 240,
              }}
              cover={<img alt="example" src={item.img} />}
              onClick={() => handleProductClick(item)}
            >
              <Meta title={item.title} />
              <div>Price: {item.price}</div>
              <Button>Add to cart</Button>
            </Card>
          </Col>
        </Row>
      ))}
    </div>
  );
};

export default FilteredPage;
