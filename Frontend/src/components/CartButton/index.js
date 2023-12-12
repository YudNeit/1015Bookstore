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
          height: "40px",
          width: "40px",
          border: "none",
          boxShadow: "none",
        }}
      ></Button>
    </div>
  );
}

export default CartButton;
