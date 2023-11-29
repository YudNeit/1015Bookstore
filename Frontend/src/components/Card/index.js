import React, { useEffect, useState } from "react";
import { Card, Col, List, Row } from "antd";

const CardItem = () => {
  const [items, setItem] = useState([]);
  const [data, setData] = useState([]);
  const empdata = [{ id: 1, name: "hang", age: 29 }];
  // const getData = () => {
  //   axios
  //     .get("http://localhost:5000/api/Products")
  //     .then((result) => {
  //       setData(result.data);
  //     })
  //     .catch((error) => {
  //       console.log(error);
  //     });
  // };

  useEffect(() => {
    // getData();
  }, []);
  return data && data.length > 0
    ? data.map((item, index) => {
        return (
          <div key={index}>
            <div>{item.id}</div>
            <div>{item.name}</div>
          </div>
        );
      })
    : "Loading";
};

export default CardItem;
