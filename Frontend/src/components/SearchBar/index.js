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
            margin: "0px",
            height: "38px",
            width: "100%",
            border: "none",
            backgroundColor: "#fcfcfc",
          }}
        >
          <AiOutlineSearch />
        </Button>
      }
      onSearch={onSearch}
      placeholder="search book"
      allowClear
      size="large"
      style={{ width: "500px", minWidth: "90%" }}
      {...props}
    />
  );
};
export default SearchBar;
