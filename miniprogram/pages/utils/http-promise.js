import {
  base_url
} from "./config.js"

class HTTP {

  request({
    url,
    data = {},
    header = {},
    method = "GET",
    success = () => {},
    fail = () => {}
  }) {
    return new Promise((resolve, reject) => {
      this._request(url, data, header, method,resolve,reject);
    })
  }

  _request(url, data, header, method,resolve,reject) {
    let that = this;
    wx.request({
      url: base_url + url,
      data: data,
      header: header,
      method: method,
      success: (res) => {
        data: {
          num: 5
        }
        if (res.statusCode = 200) {
          resolve(res.data)

        } else {
          reject();
          wx.showToast({
            title: '接口出错了^_^' + res.statusCode,
            icon: "none"
          })
        }
      },
      fail: () => {
        reject();
        wx.showToast({
          title: '接口出错了^_^' + res.statusCode,
          icon: "none"
        })
      }
    })
  }
}
export  {
  HTTP
}