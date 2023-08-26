import React, { useState, useEffect } from 'react';
import { getNguoiDungAPI } from '../api/NguoiDung/nguoidungclient';

function NguoiDungComponent() {
  const [filter, setFilter] = useState(null);
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(15);
  const [nguoiDung, setNguoiDung] = useState([]);
  const [statusButtonPrev, isDisableBtnPrev] = useState(pageNumber == 1);
  const [statusButtonNext, isDisableBtnNext] = useState(((pageNumber == nguoiDung.totalPage) || (nguoiDung.totalPage == 1)));

  useEffect(() => {
    fetchData();
  }, [filter, pageNumber, pageSize]);

  const fetchData = async () => {
    setNguoiDung(await getNguoiDungAPI(filter, pageNumber, pageSize));
  };

  useEffect(() => {
    isDisableBtnNext(((pageNumber == nguoiDung.totalPage) || (nguoiDung.totalPage == 1)));
  }, [nguoiDung.totalPage]);

  const maxButtons = 5;
  const pageButtons = [];
  const [startPage, setStartPage] = useState(1);
  const [endPage, setEndPage] = useState(1);

  useEffect(() => {
    setEndPage(Math.min(nguoiDung.totalPage, maxButtons));
  }, [nguoiDung.totalPage]);


  const updatePageButtons = () => {
    pageButtons.length = 0;
    for (let i = startPage; i <= endPage; i++) {
      pageButtons.push(
        <button
          key={i}
          className={'me-1 btn btn-sm ' + (i === pageNumber ? 'btn-primary' : 'btn-outline-primary')}
          onClick={() => {
            setPageNumber(i);
            isDisableBtnPrev(i == 1);
            isDisableBtnNext(i == nguoiDung.totalPage);
          }}
        >
          {i}
        </button>
      );
    }
  };

  updatePageButtons();

  const previousClick = () => {
    if (pageNumber == startPage && startPage > 1) {
      setStartPage(startPage - 1);
      setEndPage(endPage - 1);
    }
    if (pageNumber > 1) {
      setPageNumber(pageNumber - 1);
    }
    if (nguoiDung.pageNumber >= 1 && nguoiDung.pageNumber <= nguoiDung.totalPage) {
      isDisableBtnPrev(false);
      isDisableBtnNext(false);
    }
    if (nguoiDung.pageNumber - 1 == 1 && nguoiDung.pageNumber - 1 < nguoiDung.totalPage) {
      isDisableBtnPrev(true);
      isDisableBtnNext(false);
    }

  };

  const nextClick = () => {
    if (pageNumber == endPage && endPage < nguoiDung.totalPage) {
      setStartPage(startPage + 1);
      setEndPage(endPage + 1);
    }
    if (pageNumber < nguoiDung.totalPage) {
      setPageNumber(pageNumber + 1);
    }
    if (nguoiDung.pageNumber >= 1 && nguoiDung.pageNumber <= nguoiDung.totalPage) {
      isDisableBtnPrev(false);
      isDisableBtnNext(false);
    }
    if (nguoiDung.pageNumber + 1 == nguoiDung.totalPage) {
      isDisableBtnNext(true);
      isDisableBtnPrev(false);
    }

  };

  return (
    <div>
      <input type="text" placeholder="Search..." onBlur={e => setFilter(e.target.value)} />
      <button className='me-2 btn btn-sm btn-outline-primary' onClick={
        () => {
          setStartPage(1);
          setEndPage(maxButtons > nguoiDung.totalPage ? nguoiDung.totalPage : maxButtons);
          setPageNumber(1);
          isDisableBtnPrev(true);
          isDisableBtnNext(nguoiDung.totalPage == 1);
        }
      }>First Page</button>
      <button className={'me-2 btn btn-sm btn-outline-' + (statusButtonPrev ? 'secondary' : 'primary')} disabled={statusButtonPrev} onClick={previousClick}><i className="bi bi-arrow-left-square"></i></button>
      {pageButtons}
      <button className={'me-2 btn btn-sm btn-outline-' + (statusButtonNext ? 'secondary' : 'primary')} disabled={statusButtonNext} onClick={nextClick}><i className="bi bi-arrow-right-square"></i></button>
      <button className='btn btn-sm btn-outline-danger' onClick={
        () => {
          setStartPage(maxButtons >= nguoiDung.totalPage ? 1 : nguoiDung.totalPage - maxButtons);
          setEndPage(nguoiDung.totalPage);
          setPageNumber(nguoiDung.totalPage);
          isDisableBtnNext(true);
          isDisableBtnPrev(nguoiDung.totalPage == 1);
        }
      }>Last Page</button>
      <pre>{JSON.stringify(nguoiDung, null, 2)}</pre>
    </div>
  );

}
export default NguoiDungComponent;