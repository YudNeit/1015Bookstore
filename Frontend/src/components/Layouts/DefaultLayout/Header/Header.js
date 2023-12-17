import classNames from "classnames/bind";
import images from "../../../../assets/images";
import MenuSlide from "../../../MenuSlide";
import SearchBar from "../../../SearchBar";
import CartButton from "../../../CartButton";
import { Button } from "antd";
import { UserOutlined } from "@ant-design/icons";
import { useNavigate } from "react-router-dom";
import "../../Header.css";

const cx = classNames.bind();

function Header() {
  const navigate = useNavigate();
  return (
    <header className={cx("wrapper")}>
      <div className={cx("inner")}>
        {/* <div className={cx("menu_button")}>
          <MenuSlide />
        </div> */}

        <div className={cx("logo")}
        onClick={() => {
          navigate("/");
        }}>
          <img className="logo_image" src={images.logo} alt="1015 BookStore" />

        </div>
        <div className={cx("search_bar")}>
          <SearchBar />
        </div>
        <div className={cx("cart_button")}>
          <CartButton />
        </div>
        <div className={cx("user_button")}>
          <Button
            icon={<UserOutlined />}
            style={{
              display: "inline",
              height: "40px",
              width: "40px",
              border: "none",
              boxShadow: "none",
            }}
            onClick={() => {
              navigate("/profile_page");
            }}
          ></Button>
        </div>
      </div>
    </header>
  );
}

export default Header;
