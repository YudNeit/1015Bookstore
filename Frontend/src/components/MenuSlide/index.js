import { MenuOutlined } from "@ant-design/icons";
import { Menu } from "antd";
import { useLocation } from "react-router-dom";
import React, { useEffect, useState } from "react";

const { SubMenu } = Menu;

function getItem(label, key, icon, items, type) {
  return {
    key,
    icon,
    items,
    label,
    type,
  };
}

const categories = [
  getItem("", "", <MenuOutlined />, [
    getItem("Sách Thiếu Nhi", "1", null, [
      getItem("Đạo Đức và Kỹ Năng Sống", "12"),
      getItem("Truyện Cổ Tích", "13"),
      getItem("Văn học Thiếu Nhi", "14"),
      getItem("Tô Màu - Luyện Chữ", "15"),
    ]),
    getItem("Sách Kinh Tế", "2", null, [
      getItem("Sách Doanh Nhân", "16"),
      getItem("Sách Khởi Nghiệp", "17"),
      getItem("Sách Kinh Tế Học", "18"),
      getItem("Sách Kỹ Năng Làm Việc", "19"),
    ]),
    getItem("Sách Chính Trị", "3", null, [
      getItem("Luật - Văn bản Luật", "20"),
      getItem("Lý Luận Chính Trị", "21"),
    ]),
    getItem("Sách Tâm Lý", "4"),
    getItem("Sách Y Học", "5"),
    getItem("Sách Văn Học", "6", null, [
      getItem("Light Novel", "22"),
      getItem("Sách Thơ", "23"),
      getItem("Tiểu Thuyết", "24"),
      getItem("Truyện Tranh", "25"),
    ]),
    getItem("Sách Lịch Sử", "7"),
    getItem("Sách Tôn Giáo - Tâm Linh", "8"),
    getItem("Sách Kỹ Năng Sống", "9", null, [
      getItem("Sách Hướng Nghiệp - Kỹ năng mềm", "26"),
      getItem("Sách Nghệ Thuật Sống Đẹp", "27"),
    ]),
    getItem("Sách Tham Khảo", "10", null, [
      getItem("Sách Tham Khảo cấp I", "28"),
      getItem("Sách Tham Khảo cấp II", "29"),
      getItem("Sách Tham Khảo cấp III", "30"),
      getItem("Sách Luyện Thi Đại Học", "31"),
    ]),
    getItem("Văn Phòng Phẩm", "11", null, [
      getItem("Bút Chì", "32"),
      getItem("Tẩy", "33"),
      getItem("Bút Bi", "34"),
      getItem("Thước", "35"),
      getItem("Kéo", "36"),
    ]),
  ]),
];

const MenuSlide = ({ onMenuSelect }) => {
  const location = useLocation();
  const [selectedKeys, setSelectedKeys] = useState("/");
  const handleMenuClick = (selectedValue) => {
    onMenuSelect(selectedValue);
  };

  useEffect(() => {
    const pathName = location.pathname;
    setSelectedKeys(pathName);
  }, [location.pathname]);

  const renderMenuItems = (menuItems) => {
    return menuItems.map((item) => {
      if (item.items) {
        return (
          <SubMenu key={item.key} icon={item.icon} title={item.label}>
            {renderMenuItems(item.items)}
          </SubMenu>
        );
      } else {
        return <Menu.Item key={item.key}>{item.label}</Menu.Item>;
      }
    });
  };

  return (
    <Menu
      className="SideMenuVertical"
      theme="light"
      selectedKeys={[selectedKeys]}
      style={{ width: 200, borderRight: "none" }}
      onClick={({ key }) => handleMenuClick(key)}
    >
      {renderMenuItems(categories)}
    </Menu>
  );
};

export default MenuSlide;
