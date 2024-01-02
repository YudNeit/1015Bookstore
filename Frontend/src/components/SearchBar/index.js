// SearchBar.js

import React, { useState } from 'react';
import { Input, Button, Spin } from 'antd';
import { AiOutlineSearch } from 'react-icons/ai';
import { useNavigate } from 'react-router-dom';

const SearchBar = ({ onSearchResult, ...props }) => {
  const [searchValue, setSearchValue] = useState('');
  const navigate = useNavigate();
  const onSearch = () => {
    localStorage.setItem("datasearch", searchValue);
    navigate(`/search/${searchValue}`);
  }

  return (
    <div style={{ display: 'flex', alignItems: 'center' }}>
      <Input
        onChange={(e) => setSearchValue(e.target.value)}
        value={searchValue}
        placeholder="Search book"
        allowClear
        size="large"
        style={{
          flex: '1',
        }}
        {...props}
      />
      <Button
        style={{
          border: 'none',
          background: '#fafafa',
          boxShadow: 'none',
        }}
        onClick={onSearch}
      >
        <AiOutlineSearch />
      </Button>
    </div>
  );
};

export default SearchBar;
