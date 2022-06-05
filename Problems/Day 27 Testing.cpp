



class TestDataEmptyArray {
public:
    static vector<int> get_array() {
        vector<int> vec {};
        return vec;
    }

};

class TestDataUniqueValues {
public:
    static vector<int> get_array() {
        vector<int> vec {1, 2, 3};
        return vec;
    }

    static int get_expected_result() {
        return 0;
    }

};

class TestDataExactlyTwoDifferentMinimums {
public:
    static vector<int> get_array() {
        vector<int> vec {2, 4, 2};
        return vec;
    }

    static int get_expected_result() {
        return 0;
    }

};



