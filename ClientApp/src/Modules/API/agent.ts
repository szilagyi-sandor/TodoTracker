import axios, { AxiosResponse } from "axios";
import { Test } from "Modules/Test/_Interfaces/Test";

// TODO: Move to multiple files
// TODO: Do it from config file.
axios.defaults.baseURL = "http://localhost:5000/api";

// TODO: Add  this based on config file.
// TODO: Try catch was removed from video.
// axios.interceptors.response.use(async (response) => {
//   try {
//     await sleep(1000);

//     return response;
//   } catch (error) {
//     console.log(error);

//     return await Promise.reject(error);
//   }
// });

const getResponseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T = never>(url: string) => axios.get<T>(url).then(getResponseBody),

  post: <P = {}, R = never>(url: string, body: P) =>
    axios.post<P, AxiosResponse<R>>(url, body).then(getResponseBody),

  put: <P = {}, R = never>(url: string, body: P) =>
    axios.put<P, AxiosResponse<R>>(url, body).then(getResponseBody),

  del: <T = never>(url: string) => axios.delete<T>(url).then(getResponseBody),
};

// TODO: List can have params in here.
const Tests = {
  listTests: () => requests.get<Test[]>("/tests"),
  getTestDetails: (id: string) => requests.get<Test>(`/tests/${id}`),
  createTest: (test: Test) => axios.post<Test, void>("/tests", test),
  updateTest: (test: Test) => axios.put<Test, void>(`/tests/${test.id}`, test),
  deleteTest: (id: string) => axios.delete<void>(`/tests/${id}`),
};

const agent = {
  Tests,
};

export default agent;
