import classNames from "classnames/bind";
import images from "../../../../assets/images";
import MenuSlide from "../../../MenuSlide";
import SearchBar from "../../../SearchBar";
import CartButton from "../../../CartButton";
import { useNavigate } from "react-router-dom";
import { Button } from "antd";
import "../Header/Header.css";
const cx = classNames.bind();

function Header() {
  const navigate = useNavigate();

  return (
    <header className={cx("wrapper")}>
      <div
        className={cx("inner")}
        style={{
          display: "flex",
          marginBottom: 8,
          justifyContent: "flex-start",
        }}
      >
        <div className={cx("menu_button")}>
          <MenuSlide />
        </div>
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
        <div className={cx("login_button")}>
          <Button
            style={{
              display: "inline",
              margin: "0px",
              height: "40px",
              border: "none",
              backgroundColor: "#30CF82",
              color: "white",
            }}
            onClick={() => {
              navigate("/sign_in");
            }}
          >
            Đăng Nhập
          </Button>
        </div>
      </div>
    </header>
  );
}

export default Header;
