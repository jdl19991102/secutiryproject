
// miniprogram/pages/index/index.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    active: 1,
    tabHDate: ['股票', '最新', '涨幅'], // 标题内容
    tabW: ['230', '230', '230'],
    rowKey: ['time', 'enterTime', 'outTime'],
    rowData: [{
        time: '2020',
        enterTime: ' 20 10:00',
        outTime: ' 20 10:00',
        
      },
      {
        time: ' 02.20',
        enterTime: ' 20 10:00',
        outTime: ' 20 10:00',
        
      },
      {
        time: ' 02.20',
        enterTime: '20 10:00',
        outTime: ' 20 10:00',
       
      }
    ],
  },
  
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
        console.log(1)
    },


  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
=======
// miniprogram/pages/index/index.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    active: 1,
  },
  // onChange(event) {
  //   wx.showToast({
      
  //   });
  // },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

    },


  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
>>>>>>> 25e63febdb22c8b3f5a4aeb75408c24081a725ea
})