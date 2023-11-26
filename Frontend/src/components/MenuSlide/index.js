import {MenuOutlined} from "@ant-design/icons"
import { Menu } from 'antd';
import { useLocation, useNavigate } from "react-router-dom";
import React, { useEffect, useState } from "react";


function getItem(label, key, icon, children, type) {
  return {
    key,
    icon,
    children,
    label,
    type,
  };
}

const items = [
  getItem('', 'sub2', <MenuOutlined />, [
    getItem('Option 5', '5'),
    getItem('Option 6', '6'),
    getItem('Submenu', 'sub3', null, [getItem('Option 7', '7'), getItem('Option 8', '8')]),
  ]),
];

// const items1 = [
//   {
//     label: '',
//     key: 'Menu',
//     icon: <MenuOutlined />,
//     getItem('Navigation Two', 'sub2', <AppstoreOutlined />, [
//       getItem('Option 5', '5'),
//       getItem('Option 6', '6'),
//       getItem('Submenu', 'sub3', null, [getItem('Option 7', '7'), getItem('Option 8', '8')]),
//     ])}
// ];

const MenuSlide = () => {
  const location = useLocation();
  const [selectedKeys, setSelectedKeys] = useState("/");
  const navigate = useNavigate();

  useEffect(() => {
    const pathName = location.pathname;
    setSelectedKeys(pathName);
  }, [location.pathname]);

  return <Menu           className="SideMenuVertical"
  theme="light"
  selectedKeys={[selectedKeys]}
  style={{ width: 70 }}
  items={items}
  onClick={(item) => {
    navigate(item.key);
  }} />;
};
export default MenuSlide;
