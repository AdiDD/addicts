import axios, {AxiosRequestConfig} from "axios";

// axios.defaults.baseURL = '/api';
axios.defaults.baseURL = '/api';
// axios.defaults.baseURL = 'http://localhost:8080/api';
// axios.defaults.baseURL = '127.0.1.1:8080/api';

// axios.defaults.baseURL = '192.168.1.10:8080/api';

export default function fetcher({url, method, headers, data}: AxiosRequestConfig) {
  return axios({
    url: url,
    method: method,
    headers: headers,
    data: data
  }).then(response => response.data)
    .catch(error => error.response);
}

