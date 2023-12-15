import React from "react";
import { Input, Button, Divider } from "antd";
import { AiOutlineSearch } from "react-icons/ai";

const onSearch = (value, _e, info) => console.log(info?.source, value);
const SearchBar = (props) => {
  return (
    <Input
      addonAfter={
        <Button
          style={{
            display: "inline",
            border: "none",
            height: "100%",
            background: "#fafafa",
            boxShadow: "none",
          }}
        >
          <AiOutlineSearch />
        </Button>
      }
      onSearch={onSearch}
      placeholder="Search book"
      allowClear
      size="large"
      style={{
        minWidth: "90%",
      }}
      {...props}
    />
  );
};
export default SearchBar;
