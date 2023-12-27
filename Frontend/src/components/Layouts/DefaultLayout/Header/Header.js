import classNames from "classnames/bind";
import images from "../../../../assets/images";
import MenuSlide from "../../../MenuSlide";
import SearchBar from "../../../SearchBar";
import CartButton from "../../../CartButton";
import { Button, Menu, Dropdown } from "antd";
import { UserOutlined, LogoutOutlined } from "@ant-design/icons";
import { useNavigate } from "react-router-dom";
import "../../Header.css";

const cx = classNames.bind();

function Header() {
  const navigate = useNavigate();

  const handleLogout = () => {
    // Xóa accessToken và userid từ cookie
document.cookie = `accessToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/`;
document.cookie = `userid=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/`;

    window.location.reload();
  };

  const menu = (
    <Menu>
      <Menu.Item
        key="profile"
        icon={<UserOutlined />}
        onClick={() => {
          navigate("/profile_page");
        }}
      >
        Thông tin tài khoản
      </Menu.Item>
      <Menu.Item key="logout" icon={<LogoutOutlined />} onClick={handleLogout}>
        Đăng xuất
      </Menu.Item>
    </Menu>
  );

  return (
    <header className={cx("wrapper")}>
      <div className={cx("inner")}>
        {/* <div className={cx("menu_button")}>
          <MenuSlide />
        </div> */}

        <div
          className={cx("logo")}
          onClick={() => {
            navigate("/");
          }}
        >
          <img className="logo_image" src={images.logo} alt="1015 BookStore" />
        </div>
        <div className={cx("search_bar")}>
          <SearchBar />
        </div>
        <div className={cx("cart_button")}>
          <CartButton />
        </div>
        <div className={cx("user_button")}>
          <Dropdown overlay={menu} placement="bottomRight">
            <Button
              icon={<UserOutlined />}
              style={{
                display: "inline",
                height: "40px",
                width: "40px",
                border: "none",
                boxShadow: "none",
              }}
            ></Button>
          </Dropdown>
        </div>
      </div>
    </header>
  );
}

export default Header;
