import { Avatar, Button, Col, Image, InputNumber, List, Rate, Row } from "antd";
import React from "react";

const data = [
  {
    title: "Ant Design Title 1",
    description: "1234567890edfghjasvydasgbfklfjnldksjrl",
  },
  {
    title: "Ant Design Title 2",
  },
  {
    title: "Ant Design Title 3",
    description: "ydasgbfklfjnldksjr31231241455642342432141l",
  },
  {
    title: "Ant Design Title 4",
    description: "1hgjghj34534534534534534534ydasgbfklfjnldksjrl",
  },
];

function ProductPage() {
  return (
    <div>
      <Row>
        <Col md={6}>
          <Image src="https://salt.tikicdn.com/cache/750x750/ts/product/67/2b/2b/4b805127f2bb04452bbffcbf9ddffbe7.jpg.webp"></Image>
        </Col>
        <Col md={3}>
          <List>
            <List.Item>
              <h3>Tháng 8 Cùng Em Và Những Ký Ức Vụn Vỡ</h3>
            </List.Item>
            <List.Item>
              <Rate></Rate>
            </List.Item>
            <List.Item>Price: 105.000đ</List.Item>
            <List.Item>
              Số lượng: <InputNumber />
            </List.Item>
            <List.Item>
              <Button>Thêm vào giỏ hàng</Button>
              <Button>Mua Ngay</Button>
            </List.Item>
          </List>
        </Col>
      </Row>
      <Row>
        <List>
          <List.Item>
            <h3>Thông tin sản phẩm</h3>
          </List.Item>
          <List.Item>Danh Mục</List.Item>
          <List.Item>Nhà xuất bản:</List.Item>
          <List.Item>Nhà cung cấp:</List.Item>
          <List.Item>Tác giả:</List.Item>
          <List.Item>
            <h3>Mô tả sản phẩm</h3>
          </List.Item>
          <List.Item>
            asghjkdgjghekgesrtnkuertg;iolkt gbkhjerhgkrhgbkerjbmerskhg
            bkuiegherkujglgknekgh
          </List.Item>
        </List>
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
                    <Rate disabled defaultValue={5}/>
                    {item.description}
                  </div>
                }
              />
            </List.Item>
          )}
        />
      </Row>
    </div>
  );
}

export default ProductPage;
