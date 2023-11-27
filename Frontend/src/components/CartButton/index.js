import React from "react";
import { ShoppingCartOutlined } from "@ant-design/icons";
import { Button } from "antd";

function CartButton() {
  return (
    <div>
      <Button
        icon={<ShoppingCartOutlined />}
        style={{
          display: "inline",
          margin: "20px",
          height: "40px",
          width: "5 0px",
          border: "none",
          backgroundColor: "#fcfcfc",
        }}
      ></Button>
    </div>
  );
}

export default CartButton;
