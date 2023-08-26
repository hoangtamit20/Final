import axiosConfig from '../axios.config';

const END_POINT_API = {
    NguoiDungURL: "NguoiDung"
};

export const getNguoiDungAPI = (filter, pageNumber, pageSize) => {
    return axiosConfig.get(`${END_POINT_API.NguoiDungURL}`, {
        params: { filter, pageNumber, pageSize }
    });
};
