// components/table/table.js
Component({
  /**
   * 组件的属性列表
   */
  properties: {
    tabW: {
      // 表格每一列的宽度
      type: Array,
      value: []
    },
    tabHDate: {
      // 标题内容
      type: Array,
      value: []
    },
    rowData: {
      type: Array, // 表格数据
      value: []
    },
    rowKey: { // row属性
      type: Array,
      value: []
    }

  },

  /**
   * 组件的初始数据
   */
  data: {

  },

  /**
   * 组件的方法列表
   */
  methods: {

  }
})
