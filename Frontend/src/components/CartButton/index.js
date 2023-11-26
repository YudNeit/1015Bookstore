import React from "react";
import { ShoppingCartOutlined } from "@ant-design/icons";
import { Button, Flex } from "antd";

function CartButton() {
  return (
    <div>
      <Button
        icon={<ShoppingCartOutlined />}
        style={{
          display: "inline",
          margin: "20px",
          height: "40px",
          width: "100%",
          border: "none",
          backgroundColor: "#fcfcfc",
        }}
      ></Button>
    </div>
  );
}

export default CartButton;
