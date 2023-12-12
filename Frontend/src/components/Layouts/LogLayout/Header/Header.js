import classNames from "classnames/bind";
import images from "../../../../assets/images";
const cx = classNames.bind();
const page_name = "Trang đăng nhập";

console.log(images.logo);
function Header() {
  return (
    <header className={cx("wrapper")}>
      <div className={cx("inner log_inner")}>
        <div className={cx("logo")}>
          <img className="logo_image" src={images.logo} alt="1015 BookStore" />
        </div>
        <div className={cx("page_name")}>{page_name}</div>
      </div>
    </header>
  );
}

export default Header;
