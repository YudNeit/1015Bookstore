import React from "react";
import classNames from "classnames/bind";
//picture
import images from "../../../../assets/images";
//icon
import { CiLocationOn } from "react-icons/ci";
import { FiPhone } from "react-icons/fi";
import { MdMailOutline } from "react-icons/md";
import { FaFacebookSquare } from "react-icons/fa";
import { FiInstagram } from "react-icons/fi";
import { SiZalo } from "react-icons/si";

const cx = classNames.bind();

function Footer() {
  return (
    <div
      className={cx("inner")}
      style={{ display: "flex", marginBottom: 8, flexDirection: "row" }}
    >
      <div className={cx("logo")}>
        <img src={images.logo1} alt="1015 BookStore" />
      </div>
      <div>
        <h2>Thông tin liên hệ </h2>
        <br/>
        <a href="./"><CiLocationOn /> Trường Đại học Công nghệ Thông tin Đại học Quốc gia Thành phố Hồ Chí Minh Khu phố 6, P. Linh Trung, TP. Thủ Đức, TP.HCM</a>
        <br/>
        <a href="./"><FiPhone /> 0907448146</a>
        <br/>
        <a href="./"><MdMailOutline /> 1015.bigcompany@gmail.com</a>
        <br/>
        <a href="./"><FaFacebookSquare />&emsp;<FiInstagram />&emsp;<SiZalo /></a>
      </div>
      <div>
        <h2>Chăm sóc khách hàng</h2>
        <br/>
        <a href="./">Trung tâm trợ giúp</a>
        <br/>
        <a href="./">Bảo hành</a>
        <br/>
        <a href="./">Mua hàng</a>
        <br/>
        <a href="./">Thanh Toán</a>
        <br/>
        <a href="./">Vận chuyển</a>
        <br/>
        <a href="./">Mã giảm giá</a>
        <br/>
        <a href="./">Trả và hoàn tiền</a>
        <br/>
        <a href="./">Đánh giá sản phẩm</a>
      </div>
      <div>
        <h2>Điều khoản = Dịch vụ</h2>
        <br/>
        <a href="./">Điều khoản sử dụng</a>
        <br/>
        <a href="./">Chính sách bảo mật</a>
        <br/>
        <a href="./">Chính sách thanh toán</a>
        <br/>
        <a href="./">Chính sách vận chuyển</a>
        <br/>
        <a href="./">Chính sách xuất hóa đơn</a>
        <br/>
        <a href="./">Chính sách đổi - trả - hoàn tiền</a>
      </div>
    </div>
  );
}

export default Footer;
