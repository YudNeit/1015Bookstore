import React, { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { Button, Card, Col, Row, Pagination } from "antd";
import { useNavigate } from "react-router-dom";
import {
  fetchPaginatedProductData,
  fetchCategoryData,
} from "../../components/Data/api";
import MenuSlide from "../../components/MenuSlide";

const { Meta } = Card;

const FilteredPage = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const pathName = location.pathname;
  const initialSelectedMenu = pathName.substring(1);
  const [items, setItems] = useState([]);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [pagination, setPagination] = useState({
    current: 1,
    pageSize: 200,
    total: 0,
  });
  const [selectedMenu, setSelectedMenu] = useState(initialSelectedMenu);
  const handleMenuSelect = (selectedValue) => {
    setSelectedMenu(selectedValue);
  };
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

        // Fetch categories and set in state
        const categoriesData = await fetchCategoryData(jwtToken);
        setCategories(categoriesData);
        console.log("ádsayudsayudasgyud:" + categoriesData);

        // Fetch products based on the selected category
        const productData = await fetchPaginatedProductData(
          selectedMenu,
          pagination.current,
          pagination.pageSize,
          jwtToken
        );
        console.log("ádsayudsayudas3123gyud:" + productData);

        setItems(productData.items);
        setPagination((prev) => ({ ...prev, total: productData.totalCount }));
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [selectedMenu, pagination.current, pagination.pageSize]);
  // console.log(selectedMenu);
  const handleProductClick = (item) => {
    navigate(`/product-detail/${item.id}`, { state: { item } });
  };

  const handlePageChange = (page, pageSize) => {
    setPagination((prev) => ({ ...prev, current: page, pageSize }));
  };
  console.log(items);

  return (
    <div>
      <MenuSlide onMenuSelect={handleMenuSelect} />
      {/* Display filtered items */}
      {Array.isArray(items) ? (
        items.map((item) => (
          <Row gutter={16} key={item.name}>
            <Col span={8}>
              <Card
                hoverable
                style={{ width: 240 }}
                cover={<img alt={item.name} src={item.img} />}
                onClick={() => handleProductClick(item)}
              >
                <Meta title={item.name} />
                <div>Price: {item.price}</div>
                <Button>Add to cart</Button>
              </Card>
            </Col>
          </Row>
        ))
      ) : (
        <p>No items available.</p>
      )}
      {/* Pagination component */}
      <Pagination
        current={pagination.current}
        pageSize={pagination.pageSize}
        total={pagination.total}
        onChange={handlePageChange}
      />
    </div>
  );
};

export default FilteredPage;
